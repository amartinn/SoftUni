using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var gifts = Console.ReadLine()
                .Split()
                .ToList();
            string command;
            while ((command=Console.ReadLine())!="No Money")
            {
                var tokens = command.Split();
                var gift = tokens[1];
                if (tokens[0]== "OutOfStock")
                {
                    OutOfStock(gifts, gift);
                }
                else if (tokens[0]=="Required")
                {
                    var index = int.Parse(tokens[2]);
                    Required(gifts, gift, index);
                }
                else if (tokens[0]== "JustInCase")
                {
                    gifts[gifts.Count - 1] = gift;
                }
                
            }
            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts[i]=="None")
                {
                    gifts.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(string.Join(" ", gifts));
        }

        private static void Required(List<string> gifts, string gift, int index)
        {
            if (index>=0 && index<gifts.Count)
            {
                gifts[index] = gift;
            }
        }

        private static void OutOfStock(List<string> gifts, string gift)
        {
            for (int i = 0; i < gifts.Count; i++)
            {
                var currentGift = gifts[i];
                if (currentGift==gift)
                {
                    gifts[i] = "None";
                }
            }
        }
    }
}
