namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		private readonly static string errorMessage = "Invalid Data";
		private readonly static string successfullyImportedGame = "Added {0} ({1}) with {2} tags";
		private readonly static string successfullyImportedUser = "Imported {0} with {1} cards";
		private readonly static string successfullyImportedPurchase = "Imported {0} for {1}";
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{

			var gameDtos = JsonConvert.DeserializeObject<List<ImportGameDTO>>(jsonString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
			var sb = new StringBuilder();
			var games = new List<Game>();
			var developers = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();
			foreach (var gameDTO in gameDtos)
            {
				;
                if (!IsValid(gameDTO) || gameDTO.Tags.Count == 0)
                {
					sb.AppendLine(errorMessage);
					continue;
                }
				var developer = developers.FirstOrDefault(x => x.Name == gameDTO.Developer);
				var genre = genres.FirstOrDefault(x => x.Name == gameDTO.Genre);
                if (developer==null)
                {
					developer = new Developer { Name = gameDTO.Developer };
					developers.Add(developer);
                }
                if (genre==null)
                {
					genre = new Genre { Name = gameDTO.Genre };
					genres.Add(genre);
                }

				var gameTags = new List<GameTag>();
				var game = new Game
				{
					Name = gameDTO.Name,
					Price = gameDTO.Price,
					Genre = genre,
					Developer = developer,
					ReleaseDate = DateTime.ParseExact(gameDTO.ReleaseDate,"yyyy-MM-dd",CultureInfo.InvariantCulture),
				};
				foreach (var tag in gameDTO.Tags)
                {
					var newTag = tags.FirstOrDefault(x => x.Name == tag);
                    if (newTag==null)
                    {
						newTag = new Tag { Name = tag };
						tags.Add(newTag);
					}
					gameTags.Add(new GameTag { Game = game, Tag = newTag });

				}
				game.GameTags = gameTags;
				games.Add(game);
				
				sb.AppendLine(string.Format(successfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

			context.Developers.AddRange(developers);
			context.Genres.AddRange(genres);
			context.Games.AddRange(games);

			context.SaveChanges();
			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var userDtos = JsonConvert.DeserializeObject<List<ImportUserDTO>>(jsonString);
			var sb = new StringBuilder();
			var users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
					sb.AppendLine(errorMessage);
					continue;
                }
				var isCardValid = true;
				var cards = new List<Card>();
				foreach (var cardDTO in userDto.Cards)
                {
                    if (!IsValid(cardDTO))
                    {
						isCardValid = false;
						continue;	
					}
                    if (isCardValid)
                    {
						var card = new Card
						{
							Number = cardDTO.Number,
							Cvc = cardDTO.Cvc,
							Type = (CardType)Enum.Parse(typeof(CardType), cardDTO.Type),
						};

						cards.Add(card);
					}
                }
                if (!isCardValid)
                {
					sb.AppendLine(errorMessage);
					continue;
				}
				var user = new User
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Age = userDto.Age,
					Email = userDto.Email,
					Cards = cards
				};
				users.Add(user);
				sb.AppendLine(string.Format(successfullyImportedUser, user.Username, user.Cards.Count));
				context.Cards.AddRange(cards);
			}
			context.Users.AddRange(users);
			
			context.SaveChanges();
			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var purchasesDTO = DeserializeObject<PurchaseImportDTO>(xmlString, "Purchases");
			var sb = new StringBuilder();
            foreach (var purchaseDTO in purchasesDTO)
            {
                if (!IsValid(purchaseDTO))
                {
					sb.AppendLine(errorMessage);
					continue;
				}
				var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDTO.Card);
				var game = context.Games.FirstOrDefault(x => x.Name == purchaseDTO.Title);

				var purchase = new Purchase
				{
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDTO.Type),
					ProductKey = purchaseDTO.ProductKey,
					Date = DateTime.ParseExact(purchaseDTO.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = card,
					Game = game
				};
				context.Purchases.Add(purchase);
				sb.AppendLine(string.Format(successfullyImportedPurchase, game.Name, card.User.Username));
            }
			context.SaveChanges();
			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
		public static T[] DeserializeObject<T>(
			   string xmlObjectsAsString,
			   string xmlRootAttributeName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

			var dataTransferObjects = serializer.Deserialize(new StringReader(xmlObjectsAsString)) as T[];

			return dataTransferObjects;
		}

	}
}