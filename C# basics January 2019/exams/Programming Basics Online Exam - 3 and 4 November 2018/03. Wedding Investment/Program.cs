using System;
namespace _03.Wedding_Investment
{
    class Program
    {
        static void Main(string[] args)
        {
            string durationOfContract = Console.ReadLine().ToLower();
            string typeOfContract = Console.ReadLine().ToLower();
            string desert = Console.ReadLine().ToLower();
            int numOfmonthsToPay = int.Parse(Console.ReadLine());
            double result = 0;
            double desertResult = 0;
            if (durationOfContract == "one")
            {
                switch (typeOfContract)
                {
                    case "small":
                        {
                            result = 9.98; break;
                        }
                    case "middle":
                        {
                            result = 18.99; break;
                        }
                    case "large":
                        {
                            result = 25.98; break;
                        }
                    case "extralarge":
                        {
                            result = 35.99; break;
                        }
                }
            }
            if (durationOfContract == "two")
            {
                switch (typeOfContract)
                {
                    case "small":
                        {
                            result = 8.58; break;
                        }
                    case "middle":
                        {
                            result = 17.09; break;
                        }
                    case "large":
                        {
                            result = 23.59; break;
                        }
                    case "extralarge":
                        {
                            result = 31.79; break;
                        }
                }
                desertResult = result;
            }
            if (desert == "yes")
            {
                if (result <= 10)
                {
                    desertResult = result + 5.50;
                }
                if (result > 10 && result <= 30)
                {
                    desertResult = result + 4.35;
                }
                if (result > 30)
                {
                    desertResult = result + 3.85;
                }
            }
            else
            {
                desertResult = result;
            }
            if (durationOfContract == "two")
            {
                desertResult -= desertResult * 0.0375;
            }
            Console.WriteLine($"{desertResult * numOfmonthsToPay:f2} lv.");
        }
    }
}
