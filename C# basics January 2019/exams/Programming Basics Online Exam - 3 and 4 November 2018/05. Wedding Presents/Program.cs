using System;
namespace _05.Wedding_Presents
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double presents = int.Parse(Console.ReadLine());
            string category = string.Empty;
            double countA = 0;
            double countB = 0;
            double countV = 0;
            double countG = 0;
            double percentA = 0;
            double percentB = 0;
            double percentV = 0;
            double percentG = 0;
            for (int i = 0; i < presents; i++)
            {
                {
                    category = Console.ReadLine();
                    switch (category)
                    {
                        case "A":
                            {
                                countA++; break;
                            }
                        case "B":
                            {
                                countB++; break;
                            }
                        case "V":
                            {
                                countV++; break;
                            }
                        case "G":
                            {
                                countG++; break;
                            }
                    }
                }
                percentA = countA / presents * 100;
                percentB = countB / presents * 100;
                percentG = countG / presents * 100;
                percentV = countV / presents * 100;
            }
            double guestResult = presents / guests * 100;
            Console.WriteLine($"{percentA:f2}%");
            Console.WriteLine($"{percentB:f2}%");
            Console.WriteLine($"{percentV:f2}%");
            Console.WriteLine($"{percentG:f2}%");
            Console.WriteLine($"{guestResult:f2}%");
        }
    }
}
