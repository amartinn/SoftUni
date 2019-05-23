using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int pouredWater = 0;
            for (int i = 0; i < n; i++)
            {
                int pourWater = int.Parse(Console.ReadLine());
                if (pourWater+pouredWater>255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    pouredWater += pourWater;
                }
                
            }
            Console.WriteLine(pouredWater);
        }
    }
}
