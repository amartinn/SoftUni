using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int RectangleTables = int.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double areaPokrivka = RectangleTables * (heigth + 2 * 0.30) * (width + 2 * 0.3);
            double areaKare = RectangleTables * (heigth / 2) * (heigth / 2);
            double dollarPrice = areaPokrivka * 7 + areaKare * 9;
            double levaPrice = dollarPrice * 1.85;
            Console.WriteLine($"{dollarPrice:f2} USD");
            Console.WriteLine($"{levaPrice:f2} BGN");
        }
    }
}
