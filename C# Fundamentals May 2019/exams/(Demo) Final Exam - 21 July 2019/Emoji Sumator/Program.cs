    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    namespace Emoji_Sumator
    {
        class Program
        {
            static void Main(string[] args)
            {
            //90/100
                var EmojiPattern = @"(?<emojiName>:[a-z]{4,}:)[,.!? ]+";
                var input = Console.ReadLine();
                var emojiCode = Console.ReadLine().Split(":");
                var regex = new Regex(EmojiPattern);
                var matches = regex.Matches(input);
                var emojis = new List<string>();
                var decriptedEmojiCode = string.Empty;
                for (int i = 0; i < emojiCode.Length; i++)
                {
                    var currentValue = int.Parse(emojiCode[i]);
                    char currentChar = Convert.ToChar(currentValue);
                    decriptedEmojiCode += currentChar;
                }
                foreach (Match match in matches)
                {
                    var currentEmoji = match.Groups["emojiName"].Value;
                    emojis.Add(currentEmoji);
                }
                if (emojis.Count!=0)
                { 
                    Console.Write("Emojis found: ");
                    Console.Write(string.Join(", ", emojis));
                    Console.WriteLine();
                }
                var totalPower = 0;
                var multiplyerCount = 0;
                foreach (var emoji in emojis)
                {
                    var currentEmojiWithoutColons = emoji.Substring(1, emoji.Length-2);
                    if (currentEmojiWithoutColons==decriptedEmojiCode)
                    {
                        multiplyerCount++;
                    }
                    for (int i = 1; i < emoji.Length-1; i++)
                    {
                        totalPower += emoji[i];
                    }
                }
                for (int i = 0; i < multiplyerCount; i++)
                {
                    totalPower *= 2;
                }

                Console.WriteLine($"Total Emoji Power: {totalPower}");
            }
        }
    }
