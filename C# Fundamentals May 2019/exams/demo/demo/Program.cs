using System;
using System.Collections.Generic;
using System.Linq;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.asd = 5;
            Console.WriteLine(student.asd);
        }
    }
    class Student
    {
        private int age { get; set; }
        public int asd { private get;  set; }
    }
}
