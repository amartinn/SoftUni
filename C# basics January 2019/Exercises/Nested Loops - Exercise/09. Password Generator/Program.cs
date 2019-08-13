using System;
namespace _09.Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int count = 0;
            for (int first = 1; first < start; first++)
            {
                for (int second = 1; second < start; second++)
                {
                    for (char third = 'a'; third < end + 97; third++)
                    {
                        for (char forth = 'a'; forth < end + 97; forth++)
                        {
                            for (int fifth = 1; fifth <= start; fifth++)
                            {
                                if (fifth > first && fifth > second)
                                {
                                    Console.Write($"{first}{second}{third}{forth}{fifth} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
