using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;
            double total = 0;
            if (type =="Students")
            {
                if (day=="Friday")
                {
                    price = 8.45;
                }
                else if (day=="Saturday")
                {
                    price = 9.80;
                }
                else
                {
                    price = 10.46;
                }
                 total = people * price;
                if (people>=30)
                {
                    total -=total*0.15;
                }
            }
            else if (type=="Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else
                {
                    price = 16;
                }
                total = people * price;
                if (people >= 100)
                {
                    total -= 10 * price;
                    
                }
            }
            else
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else
                {
                    price = 22.50;
                }
                total = people * price;
                if (people >= 10 && people<=20)
                {
                    total -= total * 0.05;

                }
            }
            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
