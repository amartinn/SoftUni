using System;
namespace _07.Salary
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            string webSite = string.Empty;
            for (int i = 0; i < n; i++)
            {
                webSite = Console.ReadLine();
                switch (webSite)
                {
                    case "Facebook":
                        {
                            salary -= 150;
                            break;
                        }
                    case "Instagram":
                        {
                            salary -= 100;
                            break;
                        }
                    case "Reddit":
                        {
                            salary -= 50;
                            break;
                        }
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }
            Console.WriteLine(salary);
        }
    }
}
