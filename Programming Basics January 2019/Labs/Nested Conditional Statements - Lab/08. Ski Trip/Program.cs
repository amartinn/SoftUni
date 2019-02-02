using System;
namespace _08.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rate = Console.ReadLine();
            const double onePerson = 18;
            const double apartment = 25;
            const double presidentApp = 35;
            days -= 1;
            double result = 0;
            switch (room)
            {
                case "room for one person":
                    {
                        result = days * onePerson;
                        break;
                    }
                case "apartment":
                    {
                        result = days * apartment;
                        if (days < 10)
                        {
                            result -= result * 0.3;
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            result -= result * 0.35;
                        }
                        else
                        {
                            result -= result * 0.5;
                        }
                        break;
                    }
                case "president apartment":
                    {
                        result = days * presidentApp;
                        if (days < 10)
                        {
                            result -= result * 0.1;
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            result -= result * 0.15;
                        }
                        else
                        {
                            result -= result * 0.2;
                        }
                        break;
                    }
            }
            if (rate == "positive")
            {
                result += result * 0.25;
            }
            else
            {
                result -= result * 0.1;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
