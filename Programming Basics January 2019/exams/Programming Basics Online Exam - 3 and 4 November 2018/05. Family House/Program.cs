using System;
namespace _05.Family_House
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double electricitySum = 0;
            double waterSum = months * 20;
            double internetSum = months * 15;
            double other = 0;
            double otherSum = 0;
            for (int i = 0; i < months; i++)
            {
                double electricty = double.Parse(Console.ReadLine());
                electricitySum += electricty;
                otherSum = (electricty + 20 + 15) + (electricty + 20 + 15) * 0.2;
                other += otherSum;
            }
            double avg = (electricitySum + waterSum + internetSum + other) / months;
            Console.WriteLine($"Electricity: {electricitySum:f2} lv");
            Console.WriteLine($"Water: {waterSum:f2} lv");
            Console.WriteLine($"Internet: {internetSum:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {avg:f2} lv");
        }
    }
}
