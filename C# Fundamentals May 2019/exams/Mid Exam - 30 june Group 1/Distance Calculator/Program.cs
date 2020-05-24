using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var steps = int.Parse(Console.ReadLine());
            var lenghtOfOneStepInCm = double.Parse(Console.ReadLine());
            var distanceInMeters = int.Parse(Console.ReadLine());
            var fifthStep = lenghtOfOneStepInCm * 0.7;
            var distance = 0.0;
            for (int i = 1; i <=steps; i++)
            {
                if (i%5==0)
                {
                    distance += fifthStep;
                }
                else
                {
                    distance += lenghtOfOneStepInCm;
                }
            }
            Console.WriteLine($"You travelled {distance / distanceInMeters:f2}% of the distance!");
        }
    }
}
