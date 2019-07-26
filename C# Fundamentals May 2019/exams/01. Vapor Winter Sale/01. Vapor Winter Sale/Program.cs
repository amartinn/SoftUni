using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
            {
            var gamesAndPrice = new Dictionary<string, decimal>();
            var gamesAndDlc = new Dictionary<string, string>();
            var input = Console.ReadLine().Split(", ");
            foreach (var arg in input)  
            {
                if (arg.Contains("-"))
                {
                    var splittedInput = arg.Split("-");
                    var game = splittedInput[0];
                    var price = decimal.Parse(splittedInput[1]);
                    if (!gamesAndPrice.ContainsKey(game))
                    {
                        gamesAndPrice[game] = 0;
                    }
                    gamesAndPrice[game] += price;
                }
                else
                {
                    var splittedInput = arg.Split(":");
                    var game = splittedInput[0];
                    var dlc = splittedInput[1];
                    if (gamesAndPrice.ContainsKey(game))
                    {
                        gamesAndDlc.Add(game, dlc);
                        gamesAndPrice[game] *= 1.2M;
                    }
                }
            }
            var hasDlc = gamesAndPrice
                .OrderBy(x => x.Value)
                .Where(x => gamesAndDlc.ContainsKey(x.Key))
                .ToDictionary(x=>x.Key,y=>y.Value);
            var hasNoDlc = gamesAndPrice
                .OrderByDescending(x=>x.Value)
                .Where(x => !gamesAndDlc.ContainsKey(x.Key))
                .ToDictionary(x => x.Key, y => y.Value);


            foreach (var game in hasDlc)
            {
                gamesAndPrice[game.Key] *= 0.5M;
                Console.WriteLine($"{game.Key} - {gamesAndDlc[game.Key]} - {gamesAndPrice[game.Key]:f2}");
            }
            foreach (var game in hasNoDlc)
            {
                gamesAndPrice[game.Key] *= 0.8M;
                Console.WriteLine($"{game.Key} - {gamesAndPrice[game.Key]:f2}");
            }
            Console.WriteLine();
        }
    }
}   
