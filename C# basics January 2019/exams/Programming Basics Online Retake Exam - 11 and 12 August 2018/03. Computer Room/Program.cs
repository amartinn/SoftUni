using System;
namespace _03.Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string dayornight = Console.ReadLine();
            double tax = 0;
            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    {
                        if (dayornight == "day")
                        {
                            tax = 10.50;
                            if (people >= 4)
                            {
                                tax = tax - (tax * 0.1);
                            }
                            if (hours >= 5)
                            {
                                tax = tax - (tax * 0.5);
                            }
                        }
                        if (dayornight == "night")
                        {
                            tax = 8.4;
                            if (people >= 4)
                            {
                                tax = tax - (tax * 0.1);
                            }
                            if (hours >= 5)
                            {
                                tax = tax - (tax * 0.5);
                            }
                        }
                        break;

                    }
                case "june":
                case "july":
                case "august":
                    {
                        if (dayornight == "day")
                        {
                            tax = 12.60;
                            if (people >= 4)
                            {
                                tax = tax - (tax * 0.1);
                            }
                            if (hours >= 5)
                            {
                                tax = tax - (tax * 0.5);
                            }
                        }
                        if (dayornight == "night")
                        {
                            tax = 10.20;
                            if (people >= 4)
                            {
                                tax = 10.20 - (tax * 0.1);
                            }
                            if (hours >= 5)
                            {
                                tax = tax - (tax * 0.5);
                            }
                        }
                        break;
                    }
            }
            Console.WriteLine($"Price per person for one hour: {tax:f2}");
            Console.WriteLine($"Total cost of the visit: {(tax * people) * hours:f2}");
        }
    }
}
