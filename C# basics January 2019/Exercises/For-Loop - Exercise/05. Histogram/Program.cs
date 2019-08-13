    using System;
    namespace _05.Histogram
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
                for (int i = 0; i < n; i++)
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num<200)
                    {
                        p1++;
                    }
                    else if (num>=200 && num<=399)
                    {
                        p2++;
                    }
                    else if (num>=400 && num<=599)
                    {
                        p3++;
                    }
                    else if (num>=600 && num<=799)
                    {
                        p4++;
                    }
                    else
                    {
                        p5++;
                    }
                }
                p1 = p1 / n * 100;
                p2 = p2 / n * 100;
                p3 = p3 / n * 100;
                p4 = p4 / n * 100;
                p5 = p5 / n * 100;
                Console.WriteLine($"{p1:f2}%");
                Console.WriteLine($"{p2:f2}%");
                Console.WriteLine($"{p3:f2}%");
                Console.WriteLine($"{p4:f2}%");
                Console.WriteLine($"{p5:f2}%");
            }
        }
    }
