using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        public static Dictionary<string, int> elements;
        static void Main(string[] args)
        {
            var liquids = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            var physicalItems = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

             elements = new Dictionary<string, int>()
            {
                {"Aluminium",0 },
                {"Carbon fiber",0 },
                { "Glass",0},
                {"Lithium",0 }
            };

            while (liquids.Count>0 && physicalItems.Count>0)
            {
                var currentLiquid = liquids.Peek();
                var currentItem = physicalItems.Peek();
                var sum = currentItem + currentLiquid;
                if (checkIfSumIsEnough(sum))
                {
                    liquids.Dequeue();
                    physicalItems.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    physicalItems.Push(physicalItems.Pop()+3);
                }
            }
            if (elements.All(x=>x.Value>=1))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (liquids.Count==0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            if (physicalItems.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            foreach (var element in elements)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
        public static bool checkIfSumIsEnough(int sum)
        {
            var isEnough = true;
            if (sum==25)
            {
                elements["Glass"]++;
                
            }
            else if (sum==50)
            {
                elements["Aluminium"]++;
            }
            else if (sum==75)
            {
                elements["Lithium"]++;
            }
            else if (sum==100)
            {
                elements["Carbon fiber"]++;
            }
            else
            {
                isEnough = false;
            }
            return isEnough;
        }
        
    }
}
