using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            var persons = new List<Person>();
            while ((input=Console.ReadLine())!="End")
            {
                var tokens = input.Split();
                var person = new Person();
                person.Name = tokens[0];
                person.Id = int.Parse(tokens[1]);
                person.Age = int.Parse(tokens[2]);
                persons.Add(person);
            }
            persons = persons.OrderBy(x => x.Age).ToList();
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}
