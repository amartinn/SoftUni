using System;
namespace _06.Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int wonCount = 0, lostCount = 0, total = 0; ;
            string name = string.Empty;
            while (true)
            {
                name = Console.ReadLine();
                if (name == "End of tournaments")
                {
                    break;
                }
                int n = int.Parse(Console.ReadLine());
                total += n;
                for (int i = 1; i <= n; i++)
                {
                    int scoredPts = int.Parse(Console.ReadLine());
                    int recievedPts = int.Parse(Console.ReadLine());
                    bool win = scoredPts > recievedPts;
                    if (win)
                    {
                        Console.WriteLine($"Game {i} of tournament {name}: win with {scoredPts-recievedPts} points.");
                        wonCount++;
                    }
                    else
                    {
                        Console.WriteLine($"Game {i} of tournament {name}: lost with {Math.Abs(scoredPts - recievedPts)} points.");
                        lostCount++;
                    }
                   
                }
            }
            double winPercent =(double) wonCount / total * 100;
            Console.WriteLine($"{winPercent:f2}% matches win");
            Console.WriteLine($"{100-winPercent:f2}% matches lost");
        }
    }
}
