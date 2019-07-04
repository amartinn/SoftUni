using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsAndGrades = new Dictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());
                if (!studentsAndGrades.ContainsKey(name))
                {
                    studentsAndGrades[name] = new List<double>();
                }
                studentsAndGrades[name].Add(grade);


            }

            foreach (var student in studentsAndGrades.OrderByDescending(x=>x.Value.Average()).Where(x=>x.Value.Average()>=4.5))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");    
            }
        }
    }
}
