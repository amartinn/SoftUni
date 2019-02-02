using System;
namespace _07.Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error"); return;
                }
                else if (0 <= sales && sales <= 500)
                {
                    sales *= 0.05;
                }
                else if (500 < sales && sales <= 1000)
                {
                    sales *= 0.07;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    sales *= 0.08;
                }
                else
                {
                    sales *= 0.12;
                }
            }
            else if (city == "Varna")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error"); return;
                }
                else if (0 <= sales && sales <= 500)
                {
                    sales *= 0.045;
                }
                else if (500 < sales && sales <= 1000)
                {
                    sales *= 0.075;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    sales *= 0.1;
                }
                else
                {
                    sales *= 0.13;
                }
            }
            else if (city == "Plovdiv")
            {
                {
                    if (sales < 0)
                    {
                        Console.WriteLine("error"); return;
                    }
                    else if (0 <= sales && sales <= 500)
                    {
                        sales *= 0.055;
                    }
                    else if (500 < sales && sales <= 1000)
                    {
                        sales *= 0.08;
                    }
                    else if (1000 < sales && sales <= 10000)
                    {
                        sales *= 0.12;
                    }
                    else
                    {
                        sales *= 0.145;
                    }
                }
            }
            else
            {
                Console.WriteLine("error"); return;
            }

            Console.WriteLine($"{sales:f2}");
        }
    }
}
