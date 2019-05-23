using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            long extractedSpice = 0;
            int workersConsumption = 26;
            if (startingYield>=100)
            {
                while (startingYield >= 100) 
                {
                    daysCount++;
                    extractedSpice = (extractedSpice + startingYield) - workersConsumption;
                    startingYield -= 10;
                } 
                extractedSpice -= workersConsumption;
                Console.WriteLine(daysCount);
                Console.WriteLine(extractedSpice);
            }
            else
            {
                Console.WriteLine(daysCount);
                Console.WriteLine(extractedSpice);
            }
        }
    }
}
