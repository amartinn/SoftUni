using System;
namespace _06.Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrotherTime = double.Parse(Console.ReadLine());
            double secondBrotherTime = double.Parse(Console.ReadLine());
            double thirdBrotherTime = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double totalTime = 1 / (1 / firstBrotherTime + 1 / secondBrotherTime + 1 / thirdBrotherTime);
            totalTime *= 1.15;
            double leftTime = fatherTime - totalTime;
            Console.WriteLine($"Cleaning time: {totalTime:f2}");
            if (leftTime >= 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(leftTime)} hours.");
            }
            else if (leftTime < 0)
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(Math.Abs(leftTime))} hours.");
            }
        }
    }
}
