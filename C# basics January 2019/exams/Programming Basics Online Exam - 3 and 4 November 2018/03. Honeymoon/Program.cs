using System;
namespace _03.Honeymoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string city = Console.ReadLine().ToLower();
            int overnight = int.Parse(Console.ReadLine());
            double result = 0;
            switch (city)
            {
                case "cairo":
                    {
                        result = ((250 * 2) * overnight) + 600; break;
                    }
                case "paris":
                    {
                        result = ((150 * 2) * overnight) + 350; break;
                    }
                case "lima":
                    {
                        result = ((400 * 2) * overnight) + 850; break;
                    }
                case "new york":
                    {
                        result = ((300 * 2) * overnight) + 650; break;
                    }
                case "tokyo":
                    {
                        result = ((350 * 2) * overnight) + 700; break;
                    }
            }
            if (1 <= overnight && overnight <= 4)
            {
                if (city == "cairo" || city == "new york")
                {
                    result -= result * 0.03;
                }
            }
            if (5 <= overnight && overnight <= 9)
            {
                if (city == "cairo" || city == "new york")
                {
                    result -= result * 0.05;
                }
                if (city == "paris")
                {
                    result -= result * 0.07;
                }
            }
            if (10 <= overnight && overnight <= 24)
            {
                if (city == "cairo")
                {
                    result -= result * 0.1;
                }
                else if (city == "new york" || city == "paris" || city == "tokyo")
                {
                    result -= result * 0.12;
                }
            }
            if (25 <= overnight && overnight <= 49)
            {
                if (city == "cairo" || city == "tokyo")
                {
                    result -= result * 0.17;
                }
                if (city == "new york" || city == "lima")
                {
                    result -= result * 0.19;
                }
                if (city == "paris")
                {
                    result -= result * 0.22;
                }
            }
            if (overnight >= 50)
            {
                result -= result * 0.3;
            }
            if (result < budget)
            {
                Console.WriteLine($"Yes! You have {budget - result:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {result - budget:f2} leva.");
            }
        }
    }
}
