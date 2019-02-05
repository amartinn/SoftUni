using System;
namespace _04.Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int totalCubic = width * height * h;
            int countCubic = 0;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                int toInt = int.Parse(input);
                countCubic += toInt;

                if (countCubic > totalCubic)
                {
                    Console.WriteLine($"No more free space! You need {countCubic - totalCubic} Cubic meters more.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalCubic - countCubic} Cubic meters left.");
        }
    }
}
