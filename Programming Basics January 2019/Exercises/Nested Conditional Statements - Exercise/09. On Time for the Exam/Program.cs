using System;
namespace _09.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minuteArrive = int.Parse(Console.ReadLine());
            int totalExamMinutes = hourExam * 60 + minuteExam;
            int totalArriveMinutes = hourArrive * 60 + minuteArrive;
            int differenceHours = 0; int differenceMinutes = totalExamMinutes - totalArriveMinutes;
            // ontime
            if ((differenceMinutes > 0 && differenceMinutes <= 30) || differenceMinutes == 0)
            {
                Console.WriteLine("On time");
                if (differenceMinutes != 0)
                {
                    Console.WriteLine($"{differenceMinutes} minutes before the start");
                }
            }
            // early 

            else if (differenceMinutes > 30)
            {
                Console.WriteLine("Early");
                while (differenceMinutes > 59)
                {
                    differenceHours++;
                    differenceMinutes -= 60;
                }
                if (differenceHours > 0)
                {
                    Console.WriteLine("{0}:{1:00} hours before the start", differenceHours, differenceMinutes);
                    //Console.WriteLine($"{differenceHours}:{differenceMinutes}0 hours before the start");
                }
                else
                {
                    Console.WriteLine($"{differenceMinutes} minutes before the start");
                }
            }
            // late
            else
            {
                Console.WriteLine("Late");
                differenceMinutes = Math.Abs(differenceMinutes);
                while (differenceMinutes > 59)
                {
                    differenceHours++;
                    differenceMinutes -= 60;
                }
                if (differenceHours > 0)
                {
                    Console.WriteLine("{0}:{1:00} hours after the start", differenceHours, differenceMinutes);
                }
                else
                {
                    Console.WriteLine($"{differenceMinutes} minutes after the start");
                }
            }
        }
    }
}
