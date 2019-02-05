using System;
namespace _02.Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int grades = int.Parse(Console.ReadLine());
            int count = 0;
            double avg = 0;
            int taskCount = 0;
            string lastProblem = string.Empty;
            while (true)
            {
                string task = Console.ReadLine();
                if (task=="Enough")
                {
                    break;
                }
                int taskGrade = int.Parse(Console.ReadLine());
                avg += taskGrade;
                if (taskGrade<=4)
                {
                    count++;
                }
                if (count==grades)
                {
                    Console.WriteLine($"You need a break, {grades} poor grades.");
                    return;
                }
                 lastProblem = task;
                taskCount++;
            }
            Console.WriteLine($"Average score: {avg/taskCount:f2}");
            Console.WriteLine($"Number of problems: {taskCount}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
