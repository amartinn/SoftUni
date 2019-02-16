using System;
namespace _05.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsEachFloor = int.Parse(Console.ReadLine());
            for (int i = floors; i>=1 ; i--)
            {
                for (int j = 0; j < roomsEachFloor; j++)
                {
                    if (i==floors)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i%2==0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                } 
                Console.WriteLine();
            }
        }
    }
}
