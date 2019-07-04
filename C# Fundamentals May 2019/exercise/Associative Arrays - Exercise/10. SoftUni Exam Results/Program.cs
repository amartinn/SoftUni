using System;
using System.Linq;
using System.Collections.Generic;
namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var userAndPts = new Dictionary<string,int>();
            var languageAndCount = new SortedDictionary<string, int>();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished") 
            {
                var line = input.Split("-");
                var user = line[0];
                var language = line[1];
               
                if (language.Equals("banned"))
                {
                    userAndPts.Remove(user);
                    continue;
                }
                var pts = int.Parse(line[2]);
                if (!userAndPts.ContainsKey(user))
                {
                    userAndPts[user] = pts;
                }
                if (userAndPts[user]< pts)
                {
                        userAndPts[user] = pts;
                }
                if (!languageAndCount.ContainsKey(language))
                {
                    languageAndCount[language] = 0;
                }
                languageAndCount[language] ++;
            }
            Console.WriteLine("Results:");
            foreach (var user in userAndPts.OrderByDescending(x => x.Value).ThenBy(x=>x.Key)) 
            {
                    Console.WriteLine($"{user.Key} | {user.Value}"); 
            }
            Console.WriteLine("Submissions:");
            foreach (var language in languageAndCount )
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }
    }
}
