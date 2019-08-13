using System;
namespace _07.Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int maxASCII = int.MinValue;
            int nameASCI = 0;
            string currentWinnter = string.Empty;
            while (name!="STOP")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    nameASCI += name[i];
                }
                if (nameASCI>maxASCII)
                {
                    maxASCII = nameASCI;
                    currentWinnter = name;
                }
                nameASCI = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {currentWinnter} - {maxASCII}!");
        }
    }
}
