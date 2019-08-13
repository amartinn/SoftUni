using System;
namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();
            decimal difficulty = 0;
            decimal performance = 0;
            switch (country)
            {
                case "Russia":
                    {
                        if (instrument=="ribbon")
                        {
                            difficulty = 9.1M;
                            performance = 9.4M;
                        }
                        else if (instrument == "hoop")
                        {
                            difficulty = 9.3M;
                            performance = 9.8M;
                        }
                        else
                        {
                            difficulty = 9.6M;
                            performance = 9;
                        }
                        break;
                    }
                case "Bulgaria":
                    {
                        if (instrument == "ribbon")
                        {
                            difficulty = 9.6M;
                            performance = 9.4M;
                        }
                        else if (instrument == "hoop")
                        {
                            difficulty = 9.550M;
                            performance = 9.750M;
                        }
                        else
                        {
                            difficulty = 9.5M;
                            performance = 9.4M;
                        }
                        break;
                    }
                default:
                    {
                        if (instrument == "ribbon")
                        {
                            difficulty = 9.2M;
                            performance = 9.5M;
                        }
                        else if (instrument == "hoop")
                        {
                            difficulty = 9.450M;
                            performance = 9.350M;
                        }
                        else
                        {
                            difficulty = 9.7M;
                            performance = 9.150M;
                        }
                        break;
                    }
                   
            }
            decimal grade = difficulty + performance;
            decimal leftPts = 20 - grade;
            decimal percent = leftPts / 20 * 100;
            Console.WriteLine($"The team of {country} get {grade:f3} on {instrument}.");
            Console.WriteLine($"{percent:f2}%");
        }
    }
}
