using System;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            var family = new Family();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split();
                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);
                var person = new Person(personName, personAge);
                family.AddMember(person);

            }
            var oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
