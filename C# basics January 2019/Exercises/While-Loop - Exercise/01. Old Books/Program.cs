using System;
namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string Book = Console.ReadLine();
            int count = 0;
            int allowedBooks = int.Parse(Console.ReadLine());
            while (count<allowedBooks)
            {
                string nextBook = Console.ReadLine();
                if (nextBook==Book)
                {
                    Console.WriteLine($"You checked {count} books and found it.");
                    return;
                }
      
                count++;  
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {allowedBooks} books.");
        }
    }
}
