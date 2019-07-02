using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
            {
            var numbers = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();
                if (tokens[0] == "Change")
                {
                    var paintingNumber = int.Parse(tokens[1]);
                    var changedNumber = int.Parse(tokens[2]);
                    Change(numbers, paintingNumber, changedNumber);
                }
                else if (tokens[0] == "Hide")
                {
                    var paintingNumber = int.Parse(tokens[1]);
                    Hide(numbers, paintingNumber);
                }
                else if (tokens[0] == "Switch")
                {
                    var paintingNumber = int.Parse(tokens[1]);
                    var secondPaintingNumber = int.Parse(tokens[2]);
                    Switch(numbers, paintingNumber, secondPaintingNumber);
                }
                else if (tokens[0] == "Insert")
                {
                    var index = int.Parse(tokens[1]);
                    var paintingNumber = int.Parse(tokens[2]);
                    Insert(numbers, index, paintingNumber);
                }
                else if (tokens[0] == "Reverse")
                {
                    numbers.Reverse();
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Insert(List<int> numbers, int index, int paintingNumber)
        {
            if (index >= -1 && index <= numbers.Count)
            {
                numbers.Insert(index + 1, paintingNumber);
            }
        }

        private static void Switch(List<int> numbers, int paintingNumber, int secondPaintingNumber)
        {
            if (numbers.Contains(paintingNumber) && numbers.Contains(secondPaintingNumber))
            {
                var firstIndex = numbers.IndexOf(paintingNumber);
                var secondIndex = numbers.IndexOf(secondPaintingNumber);
                numbers[firstIndex] = secondPaintingNumber;
                numbers[secondIndex] = paintingNumber;
            }
        }

        private static void Hide(List<int> numbers, int paintingNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var current = numbers[i];
                if (current == paintingNumber)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void Change(List<int> numbers, int paintingNumber, int changedNumber)
        {
            if (numbers.Contains(paintingNumber))
            {
                var index = numbers.IndexOf(paintingNumber);
                numbers[index] = changedNumber;
            }
        }
    }
}