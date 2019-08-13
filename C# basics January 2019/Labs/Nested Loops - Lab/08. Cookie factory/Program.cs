using System;
namespace _08.Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededBatches = int.Parse(Console.ReadLine());
            int countBatches = 1;
            bool isFlour = false;
            bool isEggs = false;
            bool isSugar = false;
            string product = string.Empty;
            while (countBatches < neededBatches + 1)
            {
                product = Console.ReadLine();
                while (true)
                {
                    if (product == "sugar")
                    {
                        isSugar = true;
                    }
                    else if (product == "eggs")
                    {
                        isEggs = true;
                    }
                    else if (product == "flour")
                    {
                        isFlour = true;
                    }
                    if (isFlour && isEggs && isSugar && product == "Bake!")
                    {
                        Console.WriteLine($"Baking batch number {countBatches}...");
                        isSugar = false;
                        isEggs = false;
                        isFlour = false;
                        break;
                    }
                    else if (product == "Bake!")
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }
                    product = Console.ReadLine();
                }
                countBatches++;
            }
        }
    }
}
