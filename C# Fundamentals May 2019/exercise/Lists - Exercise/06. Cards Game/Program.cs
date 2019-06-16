using System;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var i = 0;
            while (true)
            {
               
                if (firstPlayerCards.Count==0 || secondPlayerCards.Count==0)
                {
                    break;
                }
                else if (firstPlayerCards[i] > secondPlayerCards[i])
                {
                    firstPlayerCards.Add(secondPlayerCards[i]);
                    firstPlayerCards.Add(firstPlayerCards[i]);
                    secondPlayerCards.RemoveAt(i);
                    firstPlayerCards.RemoveAt(i);
                    
                }
                else if (firstPlayerCards[i]==secondPlayerCards[i])
                {
                    firstPlayerCards.RemoveAt(i);
                    secondPlayerCards.RemoveAt(i);
                    
                }
                else if (firstPlayerCards[i] < secondPlayerCards[i])
                {
                    secondPlayerCards.Add(firstPlayerCards[i]);
                    secondPlayerCards.Add(secondPlayerCards[i]);
                    secondPlayerCards.RemoveAt(i);
                    firstPlayerCards.RemoveAt(i);
                }
               
            }
            var sum = 0;
            if (firstPlayerCards.Count>secondPlayerCards.Count)
            {
                foreach (var card in firstPlayerCards)
                {
                    sum += card;
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                foreach (var card in secondPlayerCards)
                {
                    sum += card;
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
           
        }
    }
}
