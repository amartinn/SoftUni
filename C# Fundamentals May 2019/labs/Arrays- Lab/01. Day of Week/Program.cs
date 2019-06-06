using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] day =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            var n = int.Parse(Console.ReadLine());
            if (n<1 || n>7)
            {
                Console.WriteLine("Invalid day!");
                return;
            }
            else
            {
                Console.WriteLine(day[n-1]);
            }

        }
    }
}

