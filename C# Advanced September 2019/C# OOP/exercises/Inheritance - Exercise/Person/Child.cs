
namespace Person
{
    using System;

    public class Child : Person
    {
        private int age;

        public Child(string name,int age)
            :base(name,age)
        {
            this.age = age;
        }

        public override int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value<=15)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("child age cannot be more than 15!");
                }
               
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    
}
