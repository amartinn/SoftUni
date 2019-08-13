using System;
namespace _06.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = string.Empty;
            string sleepover = "Camp";
            double result = 0;
            switch (season)
            {
                case "summer":
                    {
                        if (budget <= 100)
                        {
                            result = budget * 0.3;
                            destination = "Bulgaria";
                        }
                        else if (budget > 100 && budget <= 1000)
                        {
                            result = budget * 0.4;
                            destination = "Balkans";
                        }
                        else
                        {
                            result = budget * 0.9;
                            destination = "Europe";
                            sleepover = "Hotel";
                        }
                        break;
                    }
                case "winter":
                    {
                        sleepover = "Hotel";
                        if (budget <= 100)
                        {
                            result = budget * 0.7;
                            destination = "Bulgaria";
                        }
                        else if (budget > 100 && budget <= 1000)
                        {
                            result = budget * 0.8;
                            destination = "Balkans";
                        }
                        else
                        {
                            result = budget * 0.9;
                            destination = "Europe";
                        }
                        break;
                    }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{sleepover} - {result:f2} ");
        }
    }
}
