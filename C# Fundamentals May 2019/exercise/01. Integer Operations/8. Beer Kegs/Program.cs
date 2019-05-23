using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggerModel = string.Empty;
            double maxVolume = double.MinValue;
           
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double equation = Math.PI * radius * radius * height;
                if (equation>maxVolume)
                {
                    maxVolume = equation;
                    biggerModel = model;
                    equation = 0;
                }
            }
            Console.WriteLine(biggerModel);
            
        }
    }
}
