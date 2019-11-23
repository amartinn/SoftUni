

namespace FoodShortage
{
    using Factory.Contracts;
    using Core.Contracts;
    using IO.Contracts;


    using System.Collections.Generic;
    using FoodShortage.Core;
    using System.Linq;

    public class Engine
    {
        private IConsoleWriter writer;
        private IConsoleReader reader;
        private ICitizenFactory citizenFactory;
        private IRebelFactory rebelFactory;
        private IDictionary<string,Citizen> citizens;
        private const string EndMessage = "End";
        public Engine(IConsoleWriter writer, 
            IConsoleReader reader,
            ICitizenFactory citizenFactory,
            IRebelFactory rebelFactory,
            IDictionary<string, Citizen> citizens)
        {
            this.writer = writer;
            this.reader = reader;
            this.citizenFactory = citizenFactory;
            this.rebelFactory = rebelFactory;
            this.citizens = citizens;
        }
        public void Run()
        {
            var numberOfPeople = int.Parse(reader.Read());
            for (int i = 0; i < numberOfPeople; i++)
            {
                var personInfo = reader.Read().Split();
                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);
                Citizen citizen = null;
                if (personInfo.Length==4)
                {
                    var personId = personInfo[2];
                    var personBirthdate = personInfo[3];
                    citizen = new Person(personAge, personName, personId, personBirthdate);
                }
                else
                {
                    var rebelGroup = personInfo[2];
                    citizen = new Rebel(personAge, personName, rebelGroup);
                }
                citizens.Add(personName, citizen);
            }
            var name = string.Empty;
            while ((name=reader.Read())!=EndMessage)
            {
                if (Validator.ValidateName(name,citizens))
                {
                    citizens[name].BuyFood();
                }
            }
            var totalFoodBrougth = citizens.Values.Sum(x => x.Food);
            writer.Write(totalFoodBrougth);
            
        }
    }
}
