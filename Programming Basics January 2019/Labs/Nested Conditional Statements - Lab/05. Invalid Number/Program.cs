using System;
namespace _05.Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if ((number == 0) || (number >= 100 && number <= 200))

            {

            }

            else
            {
                Console.WriteLine("invalid");

            }
        }
    }
}
