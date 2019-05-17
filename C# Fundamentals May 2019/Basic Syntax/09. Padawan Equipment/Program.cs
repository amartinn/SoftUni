using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            int lightSaberCount = (int)Math.Ceiling(students * 1.1);
            int robeCount = students;
            double beltCount = students - (Math.Floor((double)students / 6));

            double moneyNeeded = lightSaberPrice * lightSaberCount + robesPrice * robeCount + beltsPrice * beltCount;
            double diff = amountOfMoney - moneyNeeded;
            if (diff>=0)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(diff):f2}lv more.");
            }
        }
    }
}