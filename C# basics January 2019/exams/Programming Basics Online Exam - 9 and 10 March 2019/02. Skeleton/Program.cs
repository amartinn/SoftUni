using System;
namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlMinutes = int.Parse(Console.ReadLine());
            int controlSeconds = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            int OneHundredMeter = int.Parse(Console.ReadLine());
            int totalSeconds = controlMinutes * 60 + controlSeconds;
            double loseLenght = lenght / 120;
            double totalLoseLenght = loseLenght * 2.5;
            
            double totalTime = (lenght / 100) * OneHundredMeter - totalLoseLenght;
            if (totalTime<=totalSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {totalTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {Math.Abs(totalTime-totalSeconds):f3} second slower.");
            }

        }
    }
}
