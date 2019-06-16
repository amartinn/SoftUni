using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commands;
            while ((commands = Console.ReadLine()) != "3:1")
            {
                string[] splitCommands = commands.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = splitCommands[0];
                int startIndex = int.Parse(splitCommands[1]);
                int endIndexOrPartition = int.Parse(splitCommands[2]);
                if (command == "merge")
                {
                    input = Merge(input, startIndex, endIndexOrPartition);
                }
                else if (command == "divide")
                {
                    input = Divide(input, startIndex, endIndexOrPartition);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
        public static List<string> Merge(List<string> list, int startIndex, int endIndex)
        {
            startIndex = indexValidation(startIndex, list.Count);
            endIndex = indexValidation(endIndex, list.Count);
            StringBuilder toMerge = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                toMerge.Append(list[i]);
            }
            list.RemoveRange(startIndex, endIndex - startIndex + 1);
            list.Insert(startIndex, toMerge.ToString());
            return list;
        }
        public static List<string> Divide(List<string> list, int index, int partition)
        {
            index = indexValidation(index, list.Count);
            string toDivide = list[index];
            list.RemoveAt(index);
            int toTake = toDivide.Length / partition;
            List<string> temp = new List<string>();
            string toAdd = string.Empty;
            for (int i = 1; i < partition; i++)
            {
                toAdd = toDivide.Substring(0, toTake);
                toDivide = toDivide.Substring(toTake);
                temp.Add(toAdd);
            }
            temp.Add(toDivide.Substring(0));
            list.InsertRange(index, temp);
            return list;
        }
        public static int indexValidation(int index, int arrayCount)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index > arrayCount - 1)
            {
                index = arrayCount - 1;
            }
            return index;
        }

    }
}
