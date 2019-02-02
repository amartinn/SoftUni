using System;
namespace _08.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int overnight = int.Parse(Console.ReadLine());
            double resultA = 0;
            double resultS = 0;
            string ap = "Apartment";
            string st = "Studio";

            switch (month)
            {
                case "May":
                case "October":

                    if (overnight > 7 && overnight <= 14)
                    {
                        resultS = overnight * (50 - (50 * 0.05));
                        resultA = overnight * 65;
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");
                    }
                    else if (overnight > 14)
                    {

                        resultS = overnight * (50 - (50 * 0.30));
                        resultA = overnight * (65 - (65 * 0.10));
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");

                    }
                    else
                    {
                        resultS = overnight * 50;
                        resultA = overnight * 65;
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");

                    }
                    break;
                case "June":
                case "September":

                    if (overnight > 14)
                    {
                        resultS = overnight * (75.20 - (75.20 * 0.20));
                        resultA = overnight * (68.70 - (68.70 * 0.10));
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");
                    }
                    else
                    {
                        resultS = overnight * 75.20;
                        resultA = overnight * 68.70;
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");
                    }
                    break;
                case "July":
                case "August":
                    if (overnight > 14)
                    {
                        resultS = overnight * 76;
                        resultA = overnight * (77 - (77 * 0.10));
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");
                    }
                    else
                    {
                        resultS = overnight * 76;
                        resultA = overnight * 77;
                        Console.WriteLine($"{ap}: {resultA:f2} lv.");
                        Console.WriteLine($"{st}: {resultS:f2} lv.");
                    }
                    break;

            }
        }
    }
}
