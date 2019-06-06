using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] bestDna = null;
            int bestLenght = -1;
            int startIndex = -1;
            int bestDnaSum = 0;
            int bestIndex = 0;

            int currentIndex = 0;

            while (true)
            {
                string dna = Console.ReadLine();

                if (dna == "Clone them!")
                {
                    break;
                }

                string[] currentDna = dna.Split('!', StringSplitOptions.RemoveEmptyEntries);
                int currentLenght = 0;
                int currentBestLenght = 0;
                int currentEndIndex = 0;

                for (int a = 0; a < currentDna.Length; a++)
                {
                    if (currentDna[a] == "1")
                    {
                        currentLenght++;
                        if (currentLenght > currentBestLenght)
                        {
                            currentEndIndex = a;
                            currentBestLenght = currentLenght;
                        }
                    }
                    else
                    {
                        currentLenght = 0;
                    }
                }

                int currentStartIndex = currentEndIndex - currentBestLenght + 1;

                bool isCurrentBetter = false;
                int currentDnaSum = currentDna.Select(int.Parse).Sum();

                if (currentBestLenght > bestLenght)
                {
                    isCurrentBetter = true;
                }
                else if (currentBestLenght == bestLenght)
                {
                    if (currentStartIndex < startIndex)
                    {
                        isCurrentBetter = true;
                    }
                    else if (currentStartIndex == startIndex)
                    {
                        if (currentDnaSum > bestDnaSum)
                        {
                            isCurrentBetter = true;
                        }
                    }
                }

                currentIndex++;

                if (isCurrentBetter)
                {
                    bestDna = currentDna;
                    bestLenght = currentBestLenght;
                    startIndex = currentStartIndex;
                    bestDnaSum = currentDnaSum;
                    bestIndex = currentIndex;
                }
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestDnaSum}.");
            Console.WriteLine(string.Join(' ', bestDna));


        }
                


        }
    }
