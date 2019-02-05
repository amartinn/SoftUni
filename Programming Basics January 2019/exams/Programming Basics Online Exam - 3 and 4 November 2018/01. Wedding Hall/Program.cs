using System;
namespace _01.Wedding_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double barSide = double.Parse(Console.ReadLine());

            double hallSize = height * width;
            double barSize = barSide * barSide;
            double dancing = hallSize * 0.19;
            double freeSpace = hallSize - barSize - dancing;
            double guests = Math.Ceiling(freeSpace / 3.2);
            Console.WriteLine(guests);

        }
    }
}
