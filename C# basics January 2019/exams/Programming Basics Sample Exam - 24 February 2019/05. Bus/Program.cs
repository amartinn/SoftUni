using System;
namespace _05.Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());
            int count = 0;
            
            while (count!=stops)
            {
                int leftPassengers = int.Parse(Console.ReadLine());
                int newPassengers = int.Parse(Console.ReadLine());
                passengers -= leftPassengers;
                passengers += newPassengers;
                if (count%2==0)
                {
                    passengers += 2;
                }
                else
                {
                    passengers -= 2;
                }
            
                count++;
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
