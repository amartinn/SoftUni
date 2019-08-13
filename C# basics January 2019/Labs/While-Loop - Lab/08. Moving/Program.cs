using System;
namespace _08.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            int freeSpace = width * lenght * hight;
            int totalSpace = 0;
            int spaceDiff = 0;
            string command = Console.ReadLine();
            while (command!="Done")
            {
                int space = int.Parse(command);
                totalSpace += space;
                spaceDiff = Math.Abs(totalSpace - freeSpace);
                
                if (totalSpace>=freeSpace)    
                {
                    Console.WriteLine($"No more free space! You need {spaceDiff} Cubic meters more.");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{spaceDiff} Cubic meters left.");
        }
    }
}
