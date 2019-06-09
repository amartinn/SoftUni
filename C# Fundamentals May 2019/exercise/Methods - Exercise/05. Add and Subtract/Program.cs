using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            var firstInteger = int.Parse(Console.ReadLine());
            var secondInteger = int.Parse(Console.ReadLine());
            var thirdInteger = int.Parse(Console.ReadLine());
            Console.WriteLine(Substract(Sum(firstInteger, secondInteger), thirdInteger));
        }
        static int Sum(int first, int second)
        {
            var result = first + second;
            return result;
        }
        static int Substract(int result, int thirdInteger)
        {
            return result - thirdInteger;
        }
    }
}
