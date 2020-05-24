using System;

namespace _01.Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            var companions = int.Parse(Console.ReadLine());
            var days = int.Parse(Console.ReadLine());
            var coins = days * 50;
            for (int i = 1; i <= days; i++)
            {

                if (i % 10 == 0)
                {
                    companions -= 2;
                }
                if (i % 15 == 0)
                {
                    companions += 5;
                }
                if (i % 3 == 0)
                {
                    coins -= companions * 3;
                }
                if (i % 5 == 0)
                {
                    coins += 20 * companions;
                    if (i % 3 == 0)
                    {
                        coins -= companions * 2;
                    }
                }


                coins -= companions * 2;
            }
            Console.WriteLine($"{companions} companions received {coins / companions} coins each.");
        }
    }
}