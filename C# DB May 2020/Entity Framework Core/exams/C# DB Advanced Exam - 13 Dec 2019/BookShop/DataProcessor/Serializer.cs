namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context
                .Authors
                .Select(a => new ExportAuthorBookDTO
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                    .OrderByDescending(x => x.Book.Price)
                    .Select(x => new ExportBookDTO
                    {
                        Name = x.Book.Name,
                        Price = x.Book.Price.ToString("f2")
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count)
                .ThenBy(a => a.Name)
                .ToList();


            var json = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);
            return json;

        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {

            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre ==Genre.Science)
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(x => new ExportOldestBooksDTO
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture),
                    Pages = x.Pages
                })
                .Take(10)
                .ToList();

            var xml = XmlConverter.Serialize(books, "Books");

            return xml;
        }
    }
}