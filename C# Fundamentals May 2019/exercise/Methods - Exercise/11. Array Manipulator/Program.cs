using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string commandInput;
            while ((commandInput = Console.ReadLine()) != "end")
            {
                var commandArgs = commandInput.Split();
                var command = commandArgs[0];

                if (command == "exchange")
                {
                    var index = int.Parse(commandArgs[1]);
                    if (index<0 || index>numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    else
                    {
                        Exchange(numbers, index);
                    }   
                }
                else if (command == "max")
                {
                    var keyWord = commandArgs[1];
                    if (keyWord == "odd")
                    {
                        Console.WriteLine(FindMaxOdd(numbers, keyWord));
                    }
                    else
                    {
                        Console.WriteLine(FindMaxEven(numbers, keyWord));
                    }

                }
                else if (command=="min")
                {
                    var keyWord = commandArgs[1];
                    if (keyWord == "odd")
                    {
                        Console.WriteLine(FindMinOdd(numbers, keyWord));
                    }
                    else if(keyWord=="even")
                    {
                        Console.WriteLine(FindMinEven(numbers));
                    }
                }
                else if (command =="first")
                {
                    var count = int.Parse(commandArgs[1]);
                     var keyword = commandArgs[2];
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if  (keyword == "even")
                    {
                        Console.WriteLine(string.Join(" ",FindFirstEvenElements(numbers, count, keyword)));
                    }
                    else 
                    {
                      //  FindFirstOddElements(numbers, count, keyword);
                    }
                }

            }
            Console.WriteLine(string.Join(" ", numbers));

        }

         static int[] FindFirstEvenElements(int[] numbers, int count, string keyword)
        {
            var temp = new int[count];
            var index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                if (temp.Length>1)
                {
                    return temp;
                }
               else if (currentNumber % 2 == 0) 
                {
                    temp[index] = currentNumber;
                    index++;
                }

            }
            return temp;
        }

        static int FindMinEven(int[] numbers)
        {
            int currentMinIndex = 0;
            int currentMinNumber = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                if (i % 2 == 0)
                {
                    if (currentMinNumber   > currentNumber)
                    {
                        currentMinNumber = currentNumber;
                        currentMinIndex = i;
                    }
                }
            }
            return currentMinNumber;
        }

        static int FindMinOdd(int[] numbers, string keyWord)
        {
            int currentMinIndex = -1;
            int currentMinNumber = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (currentMinNumber >= numbers[i])
                    {
                        currentMinNumber = numbers[i];
                        currentMinIndex = i;
                    }
                }
            }
            return currentMinIndex;
        }

        static int FindMaxOdd(int[] numbers, string keyword)
        {
            int currentMaxIndex = 0;
            int currentMaxNumber = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (currentMaxNumber < numbers[i])
                    {
                        currentMaxNumber = numbers[i];
                        currentMaxIndex = i;
                    }
                }
            }
            return currentMaxIndex;
        }

        static int FindMaxEven(int[] numbers, string keyWord)
        {
            int currentMaxIndex = -1;
            int currentMaxNumber = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (currentMaxNumber < numbers[i])
                    {
                        currentMaxNumber = numbers[i];
                        currentMaxIndex = i;
                    }
                }
            }
            return currentMaxIndex;
        }

        static int[] Exchange(int[] numbers, int index)
        {
            var temp = new int[index + 1];
            Array.Copy(numbers, temp, index + 1);

            var currentIndex = 0;
            for (int i = index + 1; i < numbers.Length; i++)
            {

                numbers[currentIndex] = numbers[i];
                currentIndex++;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                numbers[currentIndex] = temp[i];
                currentIndex++;
            }
            return numbers;
        }
    }
            


        }
