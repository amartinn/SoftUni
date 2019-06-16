using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var course = string.Empty;
            while (true)
            {
              var  command = Console.ReadLine().Split(":").ToList();
                if (command[0]=="course start")
                {
                    break;
                }
                if (command[0]=="Add")
                {
                     course = command[1];
                    Add(courses,course);
                }
                else if (command[0]=="Insert")
                {
                    course = command[1];
                    var index = int.Parse(command[2]);
                    Insert(courses, course, index);
                }
                else if (command[0]=="Remove")
                {
                    course = command[1];
                    Remove(courses, course);
                }
                else if (command[0]=="Swap")
                {
                    var firstCourse = command[1];
                    var secondCourse = command[2];
                    Swap(courses, firstCourse, secondCourse);
                }
                else if(command[0]=="Exercise")
                {
                    course = command[1];
                    Exercise(courses, course);
                }
               
                
            }
            
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i+1}.{courses[i]}");
            }

        }

        private static List<string> Exercise(List<string> courses, string course)
        {
            var courseIndex = -1;
            var ValidCourse = $"{course}" + "-" + "Exercise";
            if (courses.Contains(course))
            {
                
                for (int i = 0; i < courses.Count; i++)
                {

                    if (courses[i]== ValidCourse)
                    {
                        return courses;
                    }
                    if (courses[i]==course)
                    {
                        courseIndex = i;
                        break;
                    }
                }
                courses.Insert(courseIndex, ValidCourse);
            }
            else
            {
                courses.Add(course);
                courses.Add(ValidCourse);
            }
            return courses;
        }

        private static List<string> Swap(List<string> courses, string firstCourse, string secondCourse)
        {
            if (courses.Contains(firstCourse)&&courses.Contains(secondCourse))
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i]==firstCourse)
                    {
                        courses[i] = secondCourse;
                        continue;
                    }
                    else if (courses[i]==secondCourse)
                    {
                        courses[i] = firstCourse;
                        continue;
                    }
                }
            }
            var coursesToArray = courses.ToArray();
            foreach (var lesson in coursesToArray)
            {
                if (courses.Contains(lesson) && courses.Contains($"{lesson}-Exercise"))
                {
                    var courseIndex = -1;
                    var exerciseIndex = -1;
                    for (int i = 0; i < courses.Count; i++)
                    {
                        if (courses[i] == lesson)
                        {
                            courseIndex = i;
                            continue;
                        }
                        else if (courses[i] == $"{lesson}-Exercise")
                        {
                            exerciseIndex = i;
                        }
                    }
                    courses.RemoveAt(exerciseIndex);
                    courses.Insert(courseIndex + 1, $"{lesson}-Exercise");
                }
            }
            return courses;
        }

        private static List<string> Remove(List<string> courses, string course)
        {
            if (courses.Contains(course))
            {
                courses.Remove(course);
            }
            var coursesToArray = courses.ToArray();
            foreach (var lesson in coursesToArray)
            {
                if (courses.Contains(lesson) && courses.Contains($"{lesson}-Exercise"))
                {
                    var courseIndex = -1;
                    var exerciseIndex = -1;
                    for (int i = 0; i < courses.Count; i++)
                    {
                        if (courses[i] == lesson)
                        {
                            courseIndex = i;
                            continue;
                        }
                        else if (courses[i] == $"{lesson}-Exercise")
                        {
                            exerciseIndex = i;
                        }
                    }
                    courses.RemoveAt(exerciseIndex);
                    courses.RemoveAt(courseIndex);
                }
            }
            return courses;

        }

        private static List<string> Insert(List<string> courses, string course, int index)
        {
            if (courses.Contains(course))
            {
                return courses;
            }
            courses.Insert(index, course);
            return courses;
        }

        private static List<string> Add(List<string> courses,string course)
        {
            if (courses.Contains(course))
            {
                return courses;
            }
            courses.Add(course);
            return courses;
        }
    }
}
