using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private IConsoleReader reader;
        private IConsoleWriter writer;
        private IList<string> birthdays;
        private string command;
        private const string EndMessage = "End";

        public Engine(IConsoleReader reader, IConsoleWriter writer, IList<string> birthdays)
        {
            this.reader = reader;
            this.writer = writer;
            this.birthdays = birthdays;
        }

        public void Run()
        {
            while ((command = reader.Read()) != EndMessage)
            {
                var citizenInfo = command.Split();
                var citizenName = citizenInfo[1];

                ICitizen citizen = null;
                if (citizenInfo.Length == 5)
                {
                    var citizenAge = int.Parse(citizenInfo[2]);
                    var citizenId = citizenInfo[3];
                    var citizenBirthdate = citizenInfo[4];
                     citizen = new Person(citizenName, citizenId, citizenAge,citizenBirthdate);
                    birthdays.Add(citizenBirthdate);

                }
                else
                {
                    var type = citizenInfo[0];
                  
                    if (type.StartsWith("Pet"))
                    {
                        var petBirthdate = citizenInfo[2];
                        citizen = new Pet(citizenName, petBirthdate);
                        birthdays.Add(petBirthdate);
                    }
                    else
                    {
                        var robotId = citizenInfo[2];
                        citizen = new Robot(citizenName, robotId);

                    }

                    
                }

            }
            var year = Console.ReadLine();
            foreach (var date in birthdays)
            {
                if (date.EndsWith(year))
                {
                    Console.WriteLine(date);
                }
            }
        }
    }
}
