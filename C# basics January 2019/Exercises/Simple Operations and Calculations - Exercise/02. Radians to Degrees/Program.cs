using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double rads = double.Parse(Console.ReadLine());
            Console.WriteLine($"{(int)(rads * 180 / Math.PI)}");
        }
    }
}
