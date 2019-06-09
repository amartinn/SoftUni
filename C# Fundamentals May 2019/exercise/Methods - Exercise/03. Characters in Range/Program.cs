using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = char.Parse(Console.ReadLine());
            var end = char.Parse(Console.ReadLine());
            RangeBetweenChars(start,end);

        }
        static void RangeBetweenChars(char first, char second)
        {
            var start = (int)first;
            var end = (int)second;
            bool isStart = start < end;
            if (isStart)
            {
                start += 1;
                
                for (char i = (char)start; i < end; i++)
                {
                    Console.Write(i+" ");
                }
            }
            else
            {
                end += 1;
                for (char i = (char)end; i < start; i++)
                {
                    Console.Write(i+" ");
                }
            }
            
        }
    }
}
