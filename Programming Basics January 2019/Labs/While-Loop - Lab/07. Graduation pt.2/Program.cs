using System;
namespace _07.Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double excluded = 0;
            bool isExcluded = false;
            int counter = 1;
            double sum = 0;
            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    excluded++;
                }
                else if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                }
                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }
                if (!isExcluded)
                {
                    double avg = sum / 12;
                    Console.WriteLine($"{name} graduated. Average grade: {avg:f2}");
                }
                else
                {
                    Console.WriteLine($"{name} has been excluded at {counter} grade");
                }
            
        }
    }
}
