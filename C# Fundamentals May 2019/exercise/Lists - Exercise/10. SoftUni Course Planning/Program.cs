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
                string input;
                while ((input = Console.ReadLine()) != "course start")
                {
                    var splittedInput = input.Split(":");
                    var command = splittedInput[0];
                    var lesson = splittedInput[1];
                    var template = "{0}-Exercise";
                    if (command == "Add")
                    {
                        if (!courses.Contains(lesson))
                        {
                            courses.Add(lesson);
                        }
                    
                    }
                    else if (command == "Insert")
                    {
                        var index = int.Parse(splittedInput[2]);
                        if (!courses.Contains(lesson))
                        {
                            courses.Insert(index, lesson);
                        }
                    
                    }
                    else if (command == "Remove")
                    {
                        if (courses.Contains(lesson))
                        {
                            var exercise = string.Format(template, lesson);
                            if (courses.Contains(exercise))
                            {
                                var lessonIndex = courses.IndexOf(lesson);
                                courses.RemoveAt(lessonIndex);
                                courses.RemoveAt(lessonIndex);
                            }
                            courses.Remove(lesson);
                        }
                    
                    }
                    else if (command=="Swap")
                    {
                        var secondLesson = splittedInput[2];
                        if (courses.Contains(lesson)&&courses.Contains(secondLesson))
                        { var firstTemplate = string.Format(template, lesson);
                            var secondTemplate = string.Format(template, secondLesson);
                            var firstLessonIndex = courses.IndexOf(lesson);
                            var secondLessonIndex = courses.IndexOf(secondLesson);
                            courses[firstLessonIndex] = secondLesson;
                            courses[secondLessonIndex] = lesson;
                            if (courses.Contains(firstTemplate))
                            {
                                courses.RemoveAt(firstLessonIndex + 1);
                                // courses[secondLessonIndex + 1] = firstTemplate;
                                courses.Insert(secondLessonIndex + 1, firstTemplate);
                            
                            }
                            else if (courses.Contains(secondTemplate))
                            {
                           
                                courses.RemoveAt(secondLessonIndex+1);
                                courses.Insert(firstLessonIndex + 1, secondTemplate);
                            }
                        
                        }
                    
                    }
                    else if (command=="Exercise")
                    {
                        var exercise = string.Format(template, lesson);
                        if (courses.Contains(lesson))
                        {
                            var lessonIndex = courses.IndexOf(lesson);
                            courses.Insert(lessonIndex + 1, exercise);
                        }
                        else
                        {
                            courses.Add(lesson);
                            courses.Add(exercise);
                        }
                    }
               
                }
                for (int i = 1; i <=courses.Count; i++)
                {
                   Console.WriteLine($"{i}.{ courses[i - 1]}");
                }
            }
        }
    }
