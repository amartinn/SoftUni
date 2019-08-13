using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double sum = 0;
            if (projection == "Premiere")
            {
                sum = 12 * rows * cols;
                Console.WriteLine($"{sum:f2} Leva");
            }
            else if (projection == "Normal")
            {
                sum = 7.5 * rows * cols;
                Console.WriteLine($"{sum:f2} Leva");
            }
            else if (projection == "Discount")
            {
                sum = 5 * rows * cols;
                Console.WriteLine($"{sum:f2} Leva");
            }
        }
    }
}
