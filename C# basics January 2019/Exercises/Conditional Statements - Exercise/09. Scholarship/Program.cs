using System;
namespace _09.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double salary = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double excellentScholarship = 0;
            bool social = false;
            bool excellent = false;
            if (salary < minimalSalary && averageGrade > 4.5)
            {
                socialScholarship = minimalSalary * 0.35;
                social = true;
            }
            if (averageGrade >= 5.5)
            {
                excellentScholarship = averageGrade * 25;
                excellent = true;
            }
            if (social == false && excellent == false)
            {
                Console.WriteLine("You cannot get a scholarship!");
                return;
            }
            if (socialScholarship > excellentScholarship)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
            }
        }
    }
}
