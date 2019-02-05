using System;
namespace _05.Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int computersCount = int.Parse(Console.ReadLine());
            double totalSales = 0;
            double totalRating = 0;

            for (int counter = 0; counter < computersCount; counter++)
            {
                int number = int.Parse(Console.ReadLine());
                int rating = number % 10;
                int sales = number / 10;
                totalRating += rating;

                switch (rating)
                {
                    case 3:
                        totalSales += sales * 0.5;
                        break;
                    case 4:
                        totalSales += sales * 0.7;
                        break;
                    case 5:
                        totalSales += sales * 0.85;
                        break;
                    case 6:
                        totalSales += sales;
                        break;
                }
            }
            Console.WriteLine($"{totalSales:F2}");
            Console.WriteLine($"{totalRating / computersCount:F2}");
        }
    }
}
