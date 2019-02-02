using System;
namespace _05.Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());
            int timeInMinutes = startHour * 60 + startMinutes;
            int timePlus15 = timeInMinutes + 15;
            int finalhour = timePlus15 / 60;
            int finalminutes = timePlus15 % 60;
            if (finalhour >= 24)
            {
                finalhour -= 24;
            }
            if (finalminutes < 10)
            {
                Console.WriteLine($"{finalhour}:0{finalminutes}");
            }
            else
            {
                Console.WriteLine($"{finalhour}:{finalminutes}");
            }
        }
    }
}
