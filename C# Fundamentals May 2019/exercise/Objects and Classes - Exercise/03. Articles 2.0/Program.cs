using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            var articles = new List<Article>();
         
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(", ");
                var title = tokens[0];
                var content = tokens[1];
                var author = tokens[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }
            var order = Console.ReadLine();
            if (order=="title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (order=="content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
