using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                var input = Console.ReadLine().ToLower().Split();
                var command = input[0];
                if (command == "end")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    return;
                }
                else if (command == "add")
                {
                    Add(numbers, int.Parse(input[1]));
                }
                else if (command == "insert")
                {
                    if (int.Parse(input[2]) > numbers.Count - 1 || int.Parse(input[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    Insert(numbers, int.Parse(input[1]), int.Parse(input[2]));
                }
                else if (command == "remove")
                {
                    if (int.Parse(input[1]) > numbers.Count - 1 || int.Parse(input[1])<0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    Remove(numbers, int.Parse(input[1]));
                }
                else if (command == "shift")
                {


                    {
                        if (input[1] == "left")
                        {
                            ShiftLeft(numbers, int.Parse(input[2]));
                        }
                        else
                        {
                            ShiftRight(numbers, int.Parse(input[2]));
                        }

                    }
                    //  Console.WriteLine(string.Join(" ",numbers));
                }
            }
        }

         static List<int> Remove(List<int> numbers ,int index)
        {
            numbers.RemoveAt(index);
            return numbers;
        }

        static List<int> ShiftRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers;
        }

        static List<int> ShiftLeft(List<int> numbers, int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                var firstNumber = numbers[0];
                numbers.Add(firstNumber);
                numbers.RemoveAt(0);
            }
            return numbers;
        }

        static List<int> Insert(List<int> numbers,int number,int index)
        {
            numbers.Insert(index, number);
            return numbers;
        }
        static List<int> Add(List<int> numbers,int number)
        {
            numbers.Add(number);
            return numbers;
        }
    }
}
