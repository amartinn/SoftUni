using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());
            double price = 0;
            switch (restaurant)
            {
                default:
                    {
                        Console.WriteLine($"{restaurant} is invalid restaurant!");
                        return;
                    }
                case "Sushi Zone":
                    {
                        switch (sushi)
                        {
                            case "sashimi":
                                {
                                    price = 4.99;
                                    break;
                                }
                            case "maki":
                                {
                                    price = 5.29;
                                    break;
                                }
                            case "uramaki":
                                {
                                    price = 5.99;
                                    break;
                                }
                            case "temaki":
                                {
                                    price = 4.29;
                                    break;
                                }
                                
                        }
                        break;
                    }
                //sushi zone End
                case "Sushi Time":
                    {
                        switch (sushi)
                        {
                            case "sashimi":
                                {
                                    price = 5.49;
                                    break;
                                }
                            case "maki":
                                {
                                    price = 4.69;
                                    break;
                                }
                            case "uramaki":
                                {
                                    price = 4.49;
                                    break;
                                }
                            case "temaki":
                                {
                                    price = 5.19;
                                    break;
                                }
                        }
                                break;
                    }
                // sushi time End
                case "Sushi Bar":
                    {
                        switch (sushi)
                        {
                            case "sashimi":
                                {
                                    price = 5.25;
                                    break;
                                }
                            case "maki":
                                {
                                    price = 5.55;
                                    break;
                                }
                            case "uramaki":
                                {
                                    price = 6.25;
                                    break;
                                }
                            case "temaki":
                                {
                                    price = 4.75;
                                    break;
                                }
                        }

                        break;
                    }
                // sushi bar ends
                case "Asian Pub":
                    {
                        switch (sushi)
                        {
                            case "sashimi":
                                {
                                    price = 4.5;
                                    break;
                                }
                            case "maki":
                                {
                                    price = 4.8;
                                    break;
                                }
                            case "uramaki":
                                {
                                    price = 5.5;
                                    break;
                                }
                            case "temaki":
                                {
                                    price =5.5;
                                    break;
                                }
                        }
                        break;
                    }     
            }
            double total = price * portions;
            if (order=='Y')
            {
                total = (total + total * 0.2);
            }
            Console.WriteLine($"Total price: {Math.Ceiling(total)} lv.");
        }
    }
}
