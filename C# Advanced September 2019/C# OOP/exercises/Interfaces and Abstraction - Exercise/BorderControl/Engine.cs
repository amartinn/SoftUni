using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    public class Engine
    {
        private IConsoleReader reader;
        private IConsoleWriter writer;
        private Dictionary<string, ICitizen> citizens;
        private string command;
        private const string EndMessage = "End";

        public Engine(IConsoleReader reader, IConsoleWriter writer, Dictionary<string, ICitizen> citizens)
        {
            this.reader = reader;
            this.writer = writer;
            this.citizens = citizens;
        }

        public void Run()
        {
            while ((command = reader.Read()) != EndMessage)
            {
                var citizenInfo = command.Split();
                var citizenName = citizenInfo[0];
                ICitizen citizen;
                if (citizenInfo.Length == 3)
                {
                    var citizenAge = int.Parse(citizenInfo[1]);
                    var citizenId = citizenInfo[2];
                    citizen = new Person(citizenName, citizenId, citizenAge);
                }
                else
                {
                    var robotId = citizenInfo[1];
                    citizen = new Robot(citizenName, robotId);
                }
                citizens.Add(citizen.Id, citizen);
            }
            var invalidCitizenId = reader.Read();
            foreach (var citizen in citizens)
            {
                if (citizen.Key.EndsWith(invalidCitizenId))
                {
                    writer.Write(citizen.Key);
                }
            }
        }
    }
}
