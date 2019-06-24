using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {

            var articleToList = Console.ReadLine()
                .Split(", ")
                .ToList();
            var title = articleToList[0];
            var content = articleToList[1];
            var author = articleToList[2];
            Article article = new Article(title, content, author);
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(": ");
                var command = tokens[0];
                var commandArgs = tokens[1];
                if (command == "Edit")
                {
                    article.Edit(commandArgs);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(commandArgs);
                }
                else
                {
                    article.Rename(commandArgs);
                }
            }
            Console.WriteLine(article);
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
        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
