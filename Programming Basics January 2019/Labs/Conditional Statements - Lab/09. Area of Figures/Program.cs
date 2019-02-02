using System;
namespace _09.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine().ToLower();
            switch (figure)
            {
                case "square":
                    {
                        double a = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{a * a:f3}");
                        break;
                    }
                case "rectangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{b * a:f3}");
                        break;
                    }
                case "circle":
                    {
                        double r = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{Math.PI * r * r:f3}");
                        break;
                    }
                case "triangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double h = double.Parse(Console.ReadLine());
                        Console.WriteLine($"{(a * h) / 2:f3}");
                        break;
                    }
            }
        }
    }
}
