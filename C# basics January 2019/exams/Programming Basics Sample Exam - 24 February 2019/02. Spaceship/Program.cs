using System;
namespace _02.Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double average = double.Parse(Console.ReadLine());
            double rocketVolume = width * length * hight;
            double avg = 0.4;
            double roomVolume = (average + avg) * 2 * 2;
            double space = Math.Floor(rocketVolume / roomVolume);
            if (space>=3 && space<=10)
            {
                Console.WriteLine($"The spacecraft holds {space} astronauts.");
            }
            else if (space<3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        

            
        }
    }
}
