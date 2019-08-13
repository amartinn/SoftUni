using System;
namespace _05.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            int cakeArea = width * hight;
            string pieces = Console.ReadLine();
            while (true)
            {
                if (pieces=="STOP")
                {
                    Console.WriteLine($"{cakeArea} pieces are left.");
                    break;
                }
                else
                {
                    cakeArea -= int.Parse(pieces);
                    if (cakeArea<0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(cakeArea)} pieces more.");
                        break;
                    }
                }
                pieces = Console.ReadLine();
            }
        }
    }
}
