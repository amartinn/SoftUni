using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split()
                .ToList();
            string command;
            while ((command=Console.ReadLine())!="Stop")
            {
                var commandArgs = command.Split(" ");
                if (commandArgs[0] == "Delete")
                {
                    var index = int.Parse(commandArgs[1]);
                    Delete(words, index);
                }
                else if (commandArgs[0] == "Swap")
                {
                    var firstWord = commandArgs[1];
                    var secondWord = commandArgs[2];
                    Swap(words, firstWord, secondWord);
                }
                else if (commandArgs[0] == "Put")
                {
                    var word = commandArgs[1];
                    var index = int.Parse(commandArgs[2]);
                    Put(words, word, index);

                }
                else if (commandArgs[0]=="Sort")
                {
                    words.Sort();
                    words.Reverse();
                }
                else if (commandArgs[0]=="Replace")
                {
                    var firstWord = commandArgs[1];
                    var secondWord = commandArgs[2];
                    Replace(words, firstWord, secondWord);
                } 
            }
            Console.WriteLine(string.Join(" ", words));
        }

        private static void Replace(List<string> words, string firstWord, string secondWord)
        {
            if (words.Contains(secondWord))
            {
                var index = words.IndexOf(secondWord);
                words[index] = firstWord;
            }
        }

        private static void Put(List<string> words, string word, int index)
        {
            if (index>0 && index<=words.Count+1)
            {
                words.Insert(index-1, word);
                return;
            }
        }

        private static void Swap(List<string> words, string firstWord, string secondWord)
        {
            if (words.Contains(firstWord)&&words.Contains(secondWord))
            {
                
                var firstWordIndex = words.IndexOf(firstWord);
                var secondWordIndex = words.IndexOf(secondWord);
                words[firstWordIndex] = secondWord;
                words[secondWordIndex] = firstWord;
            }
        }   

        private static void Delete(List<string> words,int index)
        {

            if (index>=-1 && index+1>words.Count-1)
            {
                return;
            }
            words.RemoveAt(index + 1);
        }
    }
}
