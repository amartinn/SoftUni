using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
           var coursesAndStudnets = new Dictionary<string, List<string>>();
            var input = string.Empty;
            while ((input=Console.ReadLine())!="end")
            {
                var line = input.Split(" : ");
                var course = line[0];
                var student = line[1];
                if (!coursesAndStudnets.ContainsKey(course))
                {
                    coursesAndStudnets[course] = new List<string>();
                   
                }
                coursesAndStudnets[course].Add(student);

            }
            foreach (var course in coursesAndStudnets.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var name in course.Value.OrderBy(n=>n))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
