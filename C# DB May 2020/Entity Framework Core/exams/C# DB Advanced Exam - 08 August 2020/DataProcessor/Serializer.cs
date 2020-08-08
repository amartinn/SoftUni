namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{


			var gamesByGenres = context
				.Genres
				.Where(x => genreNames.ToList().Contains(x.Name))
				.ToList()
				.Select(g => new ExportGameByGenre
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games.Where(x => x.Purchases.Any())
					.ToList()
					.Select(x => new ExportGameJsonDTO
					{
						Id = x.Id,
						Title = x.Name,
						Developer = x.Developer.Name,
						Tags = string.Join(", ", x.GameTags.Select(x => x.Tag.Name)),
						Players = x.Purchases.Count()
					})
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id).ToList()
		}).ToList();

            foreach (var game in gamesByGenres)
            {
				game.TotalPlayers = game.Games.Select(x => x.Players).Sum();

			}
			gamesByGenres = gamesByGenres.OrderByDescending(x => x.TotalPlayers)
					.ThenBy(x => x.Id)
					.ToList();


			var jsonString = JsonConvert.SerializeObject(gamesByGenres,Formatting.Indented);
			return jsonString;
				
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var @enum = (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType);

			var users = context.Users
				.ToArray()
				.Select(u => new ExportUserDTO
				{
					Username = u.Username,
					Purchases = context.Purchases.Where(x => x.Card.User.Id == u.Id && @enum == x.Type)

					.OrderBy(x => x.Date)

					.Select(x => new ExportPurchaseDTO
					{
						Card = x.Card.Number,
						Cvc = x.Card.Cvc,
						Date = x.Date.ToString("yyyy-MM-dd HH:mm"),
						Game = new ExportGameDTO
						{
							Genre = x.Game.Genre.ToString(),
							Price = x.Game.Price,
							Title = x.Game.Name
						}
					}).ToArray()
				}).ToArray()
				.Where(x => x.Purchases.Any(x => x.Game.Price > 0))
				.ToArray();
			;
            foreach (var user in users)
            {
				user.TotalSpent = user.Purchases.Select(x => x.Game.Price).Sum();

            }
			users = users.OrderByDescending(x => x.TotalSpent).ThenBy(x => x.Username).ToArray();
			var xml = Serialize(users, "Users");
			return xml;
		}

						
			public static string Serialize<T>(
			T[] dataTransferObjects,
			string xmlRootAttributeName)
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));

				var builder = new StringBuilder();

				using (var writer = new StringWriter(builder))
				{
					serializer.Serialize(writer, dataTransferObjects, GetXmlNamespaces());
				}


				return builder.ToString();
			}
		
		private static XmlSerializerNamespaces GetXmlNamespaces()
		{
			XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
			xmlNamespaces.Add(string.Empty, string.Empty);
			return xmlNamespaces;
		}
	}
	
}
