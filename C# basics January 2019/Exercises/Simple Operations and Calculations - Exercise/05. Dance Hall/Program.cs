using System;


namespace _05.Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());
            double hallSize = (L * 100) * (W * 100);
            double WardrobeSize = A * 100;
            WardrobeSize *= WardrobeSize;
            double benchSize = hallSize / 10;
            double Left = hallSize - WardrobeSize - benchSize;
            double Dancers = Left / (40 + 7000);
            Console.WriteLine((int)Dancers);
        }
    }
}
