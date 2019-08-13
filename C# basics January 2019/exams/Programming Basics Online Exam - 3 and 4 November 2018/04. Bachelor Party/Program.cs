using System;
namespace _04.Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int singerSum = int.Parse(Console.ReadLine());
            int numberPeopleInGroup = 0;
            int reservation = 0;
            int income = 0;
            string command = Console.ReadLine();
            int totalnumberPeopleInGroup = 0;
            while (true)
            {
                income = reservation + income;
                if (command == "The restaurant is full" && singerSum <= income)
                {
                    Console.WriteLine($"You have {totalnumberPeopleInGroup} guests and {income - singerSum} leva left.");
                    break;
                }
                else if (command == "The restaurant is full" && singerSum > income)
                {
                    Console.WriteLine($"You have {totalnumberPeopleInGroup} guests and {income} leva income, but no singer.");
                    break;
                }
                else

                {
                    numberPeopleInGroup = int.Parse(command);
                    command = Console.ReadLine();
                    if (numberPeopleInGroup < 5)
                    {
                        reservation = 100 * numberPeopleInGroup;
                    }
                    else if (numberPeopleInGroup >= 5)
                    {
                        reservation = 70 * numberPeopleInGroup;
                    }
                    totalnumberPeopleInGroup += numberPeopleInGroup;
                }
            }
        }
    }
}
