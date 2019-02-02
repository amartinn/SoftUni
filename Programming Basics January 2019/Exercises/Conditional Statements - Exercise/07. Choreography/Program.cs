using System;
namespace _07.Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int daysToStudy = int.Parse(Console.ReadLine());
            double totalStepsForDay = (steps / daysToStudy);
            totalStepsForDay /= steps;
            totalStepsForDay *= 100;
            totalStepsForDay = Math.Ceiling(totalStepsForDay);
            double percentForeachDancer = totalStepsForDay / dancers;
            if (totalStepsForDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentForeachDancer:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {percentForeachDancer:f2}% steps to be learned per day.");
            }
        }
    }
}
