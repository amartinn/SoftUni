namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context
                .Books
                .Select(b => new
                {
                    AgeRestriction = b.AgeRestriction.ToString().ToLower(),
                    b.Title
                }
                )
                .ToList()
                .Where(b => b.AgeRestriction == command)
                .ToList()
                .OrderBy(b => b.Title);
            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title}"));
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks =
                context
                .Books
                .Where(b =>b.EditionType == EditionType.Gold &&  b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();
            return string.Join(Environment.NewLine, goldenBooks.Select(b => $"{b.Title}"));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books =
                context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();
            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();
            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title}"));
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToList();

            var books = context
                .Books
                .Where(b => b.BookCategories
                .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date,"dd-MM-yyyy",null);
            var books = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}"));


        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });
            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FirstName} {a.LastName}"));

        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);

        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    bookAuthorName = $"{b.Author.FirstName} {b.Author.LastName}",
                    b.Title
                })
                .ToList();
            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.bookAuthorName})"));

        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
            return count;
               
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copyesByAuthor = context
                .Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(b => b.Copies)
                .ToList();
            return string.Join(Environment.NewLine, copyesByAuthor.Select(c => $"{c.Name} - {c.Copies}"));
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitByCategory = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    totalProfit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(c => c.totalProfit)
                .ToList();

            return string.Join(Environment.NewLine, totalProfitByCategory.Select(tp => $"{tp.Name} ${tp.totalProfit:f2}"));
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    mostReentbooks = c.CategoryBooks
                    .OrderByDescending(c => c.Book.ReleaseDate.Value.Year)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c=> c.Name)
                .ToList();
            var sb = new StringBuilder();
            foreach (var category in mostRecentBooks)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.mostReentbooks)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }
            return sb.ToString().TrimEnd();

        }
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToList()
            .ForEach(b => b.Price += 5);
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeRemoved = context.Books
            .Where(b => b.Copies < 4200)
            .ToList();

            context.RemoveRange(booksToBeRemoved);
            context.SaveChanges();

            return booksToBeRemoved.Count;
        }
    }
}










































































































































