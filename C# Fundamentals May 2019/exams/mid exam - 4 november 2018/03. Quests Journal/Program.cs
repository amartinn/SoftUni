using System;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            var quests = Console.ReadLine()
                .Split(", ")
                .ToList();
            string input;
            while ((input=Console.ReadLine())!="Retire!")
            {
                var splittedInput = input.Split(" - ");
                var command = splittedInput[0];
                if (command=="Start")
                {
                    var quest = splittedInput[1];
                    if (!quests.Contains(quest))
                    {
                        quests.Add(quest);
                    }
                    continue;
                }
                else if (command=="Complete")
                {
                    var quest = splittedInput[1];
                    if (quests.Contains(quest))
                    {
                        quests.Remove(quest);
                    }
                }
                else if (command=="Side Quest")
                {
                    var splittedSideQuest = splittedInput[1].Split(":");
                    var quest = splittedSideQuest[0];
                    var sideQuest = splittedSideQuest[1];
                    if (quests.Contains(quest) && !quests.Contains(sideQuest))
                    {
                        var questIndex = quests.IndexOf(quest);
                        quests.Insert(questIndex+1, sideQuest);
                    }
                }
                else if (command=="Renew")
                {
                    var quest = splittedInput[1];
                    if (quests.Contains(quest))
                    {
                        var questIndex = quests.IndexOf(quest);
                        quests.RemoveAt(questIndex);
                        quests.Add(quest);
                    }
                    
                }

            }
            Console.WriteLine(string.Join(", ",quests));
        }
    }
}
