using System;
namespace _01.Shopping_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForRelax = int.Parse(Console.ReadLine());
            double onePeriferiaPrice = double.Parse(Console.ReadLine());
            double programPrice = double.Parse(Console.ReadLine());
            double frapePrice = double.Parse(Console.ReadLine());
            timeForRelax -= 5;
            const int periferia = 6;
            const int program = 4;
            timeForRelax = timeForRelax - (periferia + program);
            double periferiaPrice = onePeriferiaPrice * 3;
            double programm = programPrice * 2;
            double total = periferiaPrice + programm + frapePrice;
            Console.WriteLine($"{total:f2}");
            Console.WriteLine(timeForRelax);
        }
    }
}
