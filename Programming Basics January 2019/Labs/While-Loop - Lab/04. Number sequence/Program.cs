using System;
namespace _04.Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            string command = Console.ReadLine();
            while (command!="END")
            {
                int num = int.Parse(command);
                if (num<minNumber)
                {
                    minNumber = num;
                }
                if (num>maxNumber)
                {
                    maxNumber = num;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
