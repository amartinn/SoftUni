using System;
namespace _09.Magic_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());
            for (int first= 1; first <= 9; first++)
            {
                for (int second = 1; second <= 9; second++)
                {
                    for (int third = 1; third <= 9; third++)    
                    {
                        for (int forth = 1; forth <=9; forth++)
                        {
                            for (int fifth = 1; fifth <= 9; fifth++)
                            {
                                for (int sixth = 1; sixth <=9; sixth++)
                                {
                                    int sum = first * second * third * forth * fifth * sixth;
                                    if (sum == magicNumber)
                                    {
                                        Console.Write($"{first}{second}{third}{forth}{fifth}{sixth} ");      
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
