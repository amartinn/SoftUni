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

			throw new NotImplementedException();
		}

	}
	
}
