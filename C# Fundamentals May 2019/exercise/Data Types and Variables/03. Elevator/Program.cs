using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            if (numberOfPeople%capacity==0)
            {
                Console.WriteLine(numberOfPeople/capacity);
            }
            else
            {
                Console.WriteLine((numberOfPeople / capacity) + 1);
            }
           
        }
    }
}
