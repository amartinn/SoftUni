using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine().Split(", "));
            while (songs.Count>0)
            {
                var commandArgs = Console.ReadLine()
                    .Split()
                    .ToArray();
                var command = commandArgs[0];
                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        var songName = string.Empty;
                        for (int i = 1; i < commandArgs.Length; i++)
                        {
                            songName += commandArgs[i] + " ";
                        }
                        songName = songName.Trim();
                        if (songs.Contains(songName))
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(songName);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",songs));
                        break;
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}
