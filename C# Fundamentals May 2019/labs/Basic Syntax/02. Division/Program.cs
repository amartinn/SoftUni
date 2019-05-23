using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            // 2 3 6 7 10
            int devNum = 0;
            
             if (num%2==0)
            {
                devNum = 2;
                if (num%3==0)
                {
                    devNum = 6;
                }
                else if (num % 10 == 0)
                {
                    devNum = 10;
                }
                else if (num%7==0)
                {
                    devNum = 7;
                }
                else if (num%6==0)
                {
                    devNum = 6;
                }

            }
            if (num%3==0)
            {
                devNum = 3;
                if (num%7==0)
                {
                    devNum = 7;
                }
                if(num%6==0)
                {
                    devNum = 6;
                }
               
            }
            if (num%7==0)
            {
                devNum = 7;
            }
            if (num%10==0)
            {
                devNum = 10;
            }
            if (devNum == 0)
            {
                Console.WriteLine("Not divisible");
                return;
            }
            else
            {
                Console.WriteLine($"The number is divisible by {devNum}");
            }
            
        }
    }
}
