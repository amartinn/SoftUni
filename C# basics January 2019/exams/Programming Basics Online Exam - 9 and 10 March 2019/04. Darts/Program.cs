using System;
namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int successfullCount = 0;
            int unsucessfullCount = 0;
            int totalPts = 301;
            while (true)
            {
                if (totalPts<=0)
                {
                    Console.WriteLine($"{playerName} won the leg with {successfullCount} shots.");
                    return;
                }
                string side = Console.ReadLine();
                if (side=="Retire")
                {
                    Console.WriteLine($"{playerName} retired after {unsucessfullCount} unsuccessful shots.");
                    return;
                }
                int pts = int.Parse(Console.ReadLine());
                switch (side)
                {
                    case "Double":
                        {
                            pts*= 2;
                            break;
                        }
                    case "Triple":
                        {
                            pts *= 3;
                            break;
                        }
                }
                bool sucessfull = totalPts - pts >= 0;
                bool unsucessfull = totalPts - pts < 0;
                if (sucessfull)
                {
                    successfullCount++;
                    totalPts -= pts;
                }
                if (unsucessfull)
                {
                    unsucessfullCount++;

                }              
            }
        }
    }
}
