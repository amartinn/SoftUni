using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecordInSeconds = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());
            double totalSeconds = distance * timeForOneMeter;
            double bonusTime = Math.Floor(distance / 15) * 12.5;
            double totalTime = (totalSeconds + bonusTime);
            if (worldRecordInSeconds > totalTime)
            {

                Console.WriteLine($"Yes, he succeeded! The new world record is {(totalTime):f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(totalTime - worldRecordInSeconds):f2} seconds slower.");

            }
        }
    }
}
