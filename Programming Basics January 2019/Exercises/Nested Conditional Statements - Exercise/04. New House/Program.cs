using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double result = 0;
            switch (flower)
            {
                case "Roses":
                    {
                        result = quantity * 5;
                        if (quantity > 80)
                        {
                            result -= result * 0.1;
                        }
                        break;
                    }
                case "Dahlias":
                    {
                        result = quantity * 3.8;
                        if (quantity > 90)
                        {
                            result -= result * 0.15;
                        }
                        break;
                    }
                case "Tulips":
                    {
                        result = quantity * 2.8;
                        if (quantity > 80)
                        {
                            result -= result * 0.15;
                        }
                        break;
                    }
                case "Narcissus":
                    {

                        if (quantity < 120)
                        {
                            result = quantity * 3 + ((quantity * 3) * 0.15);

                        }
                        else
                        {
                            result = quantity * 3;
                        }
                        break;
                    }
                case "Gladiolus":
                    {

                        if (quantity < 80)
                        {
                            result = quantity * 2.5 + ((quantity * 2.5) * 0.2);

                        }
                        else
                        {
                            result = quantity * 2.5;
                        }
                        break;
                    }

            }
            if (budget >= result)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flower} and {budget - result:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {result - budget:f2} leva more.");
            }
        }
    }
}
