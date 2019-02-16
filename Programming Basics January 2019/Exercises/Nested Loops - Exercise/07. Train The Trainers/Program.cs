using System;
namespace _07.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryMembers = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            string currentPresentation = string.Empty;
            double grade = 0;
            double avgGrade = 0;
            double allPresentationScore = 0;
            int scoreCounter = 0;
            double result = 0;
            while (true)
            {
                if (presentationName == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {result / scoreCounter:f2}.");
                    break;
                }
                for (int i = 0; i < juryMembers; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    avgGrade += grade;
                }
                currentPresentation = presentationName;
                allPresentationScore += avgGrade / juryMembers;
                result += allPresentationScore;
                Console.WriteLine($"{currentPresentation} - {allPresentationScore:f2}.");
                allPresentationScore = 0;
                avgGrade = 0;
                grade = 0;
                scoreCounter++;
                presentationName = Console.ReadLine();
            }
        }
    }
}
