

namespace Person
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person person = new Person(name, age);
            if (age<=15)
            {
                person = new Child(name, age);
            }
            Console.WriteLine(person);
        }
    }
}