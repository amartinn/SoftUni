using System;


namespace _09.Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            percent = percent * 0.01;
            double volume = height * width * h;
            double totalVolume = volume * 0.001;
            double total = totalVolume * (1 - percent);
            Console.WriteLine($"{total:f3}");
        }
    }
}
