namespace Person
{
    using System;

    public class Person
    {
        private int age;

        public Person(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual int Age
        {
            get
            {
                return this.age; 
            }
            set
            {
                if (value>=0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("age cannot be negative!");
                }
               
            }
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
