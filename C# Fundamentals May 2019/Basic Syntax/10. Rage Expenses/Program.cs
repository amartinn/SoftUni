using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double rageExpenses = 0;
            int dispCount = 0;
            for (int i = 1; i <=lostGames; i++)
            {
                if (i%2==0 && i%3==0)
                {
                    rageExpenses += (headSetPrice+mousePrice+keyboardPrice);
                    dispCount++;
               
                }
                else if (i%2==0)
                {
                    rageExpenses += headSetPrice;
          
                }
                else if (i%3==0)
                {
                    rageExpenses += mousePrice;
             
                }
                if (dispCount % 2 == 0 && dispCount!=0)
                {
                    rageExpenses += displayPrice;
                
                    dispCount = 0;
                }
               
            }
            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
