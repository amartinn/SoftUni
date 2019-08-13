using System;
namespace _02.Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            string city = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            switch (city)
            {
                case "sofia":
                    {
                        if (product == "coffee")
                        {
                            quantity *= 0.5;
                        }
                        else if (product == "water")
                        {
                            quantity *= 0.8;
                        }
                        else if (product == "beer")
                        {
                            quantity *= 1.2;

                        }
                        else if (product == "sweets")
                        {
                            quantity *= 1.45;
                        }
                        else
                        {
                            quantity *= 1.6;
                        }
                        break;
                    }
                case "plovdiv":
                    {
                        if (product == "coffee")
                        {
                            quantity *= 0.4;
                        }
                        else if (product == "water")
                        {
                            quantity *= 0.7;
                        }
                        else if (product == "beer")
                        {
                            quantity *= 1.15;

                        }
                        else if (product == "sweets")
                        {
                            quantity *= 1.3;
                        }
                        else
                        {
                            quantity *= 1.5;
                        }
                        break;
                    }
                case "varna":
                    {
                        if (product == "coffee")
                        {
                            quantity *= 0.45;
                        }
                        else if (product == "water")
                        {
                            quantity *= 0.7;
                        }
                        else if (product == "beer")
                        {
                            quantity *= 1.1;

                        }
                        else if (product == "sweets")
                        {
                            quantity *= 1.35;
                        }
                        else
                        {
                            quantity *= 1.55;
                        }
                        break;
                    }
            }
            Console.WriteLine(quantity);
        }
    }
}
