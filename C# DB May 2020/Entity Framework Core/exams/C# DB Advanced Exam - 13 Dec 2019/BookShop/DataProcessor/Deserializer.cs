namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.Configuration;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using ProductShop.XMLHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {

        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";
        public static string ImportBooks(BookShopContext context, string xmlString)
        {

            const string root = "Books";
            var bookDTOs = XmlConverter.Deserializer<BookDTO>(xmlString, root);
            var sb = new StringBuilder();
            var booksToImport = new List<Book>();
            foreach (var book in bookDTOs)
            {
                ; 
                var isEnumDefined = Enum.IsDefined(typeof(Genre), int.Parse(book.Genre));
                var isDateValid = DateTime.TryParseExact(book.PublishedOn.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,out var publishedOn);
                if (!IsValid(book) || !isEnumDefined || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var bookToImport = new Book
                {
                    Name = book.Name,
                    Pages = book.Pages,
                    Genre = (Genre)Enum.Parse(typeof(Genre),book.Genre),
                    Price = book.Price,
                    PublishedOn = publishedOn
                };
            sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            booksToImport.Add(bookToImport);
        }
            context.Books.AddRange(booksToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }
        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDTO = JsonConvert.DeserializeObject<AuthorWithBooksDTO[]>(jsonString, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
            var sb = new StringBuilder();
            var authors = new List<Author>();

            foreach (var authorDTO in authorsDTO)
            {
                var isEmailNull = authors.FirstOrDefault(x => x.Email == authorDTO.Email) != null;
                if (!IsValid(authorDTO) || isEmailNull)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var author = new Author
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Email = authorDTO.Email,
                    Phone = authorDTO.Phone,
                };

                var authorBooks = new List<AuthorBook>();
                foreach (var authorBook in authorDTO.Books)
                {
                    var book = context.Books.Find(authorBook.Id);
                    if (book == null)
                    {
                        continue;
                    }
                    authorBooks.Add(new AuthorBook { Author = author, Book = book    });
                }
                if (authorBooks.Count > 0)
                {
                    author.AuthorsBooks = authorBooks;
                    authors.Add(author);
                    sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }
            context.Authors.AddRange(authors);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}