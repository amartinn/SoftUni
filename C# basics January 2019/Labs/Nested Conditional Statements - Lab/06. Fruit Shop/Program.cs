using System;
namespace _06.Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 2.7;
                            }
                            else
                            {
                                quantity *= 2.5;
                            }
                            break;
                        }
                    case "apple":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 1.25;
                            }
                            else
                            {
                                quantity *= 1.2;
                            }
                            break;
                        }
                    case "orange":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 0.9;
                            }
                            else
                            {
                                quantity *= 0.85;
                            }
                            break;
                        }
                    case "grapefruit":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 1.60;
                            }
                            else
                            {
                                quantity *= 1.45;
                            }
                            break;
                        }
                    case "kiwi":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 3;
                            }
                            else
                            {
                                quantity *= 2.7;
                            }
                            break;
                        }
                    case "pineapple":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 5.6;
                            }
                            else
                            {
                                quantity *= 5.5;
                            }
                            break;
                        }
                    case "grapes":
                        {
                            if (day == "Saturday" || day == "Sunday")
                            {
                                quantity *= 4.2;
                            }
                            else
                            {
                                quantity *= 3.85;
                            }
                            break;
                        }
                    default: Console.WriteLine("error"); return;
                }
                Console.WriteLine($"{quantity:f2}");
            }
            else
            {
                Console.WriteLine("error"); return;
            }
        }
    }
}
