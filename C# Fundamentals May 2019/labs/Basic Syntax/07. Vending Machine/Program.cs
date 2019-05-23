using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double sumOfInsertedCoins = 0;
            double price = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Start")
                {
                    break;
                }
                double inputCoin = double.Parse(input);
                if (inputCoin == 0.1|| inputCoin==0.2 || inputCoin==0.5|| inputCoin==1 || inputCoin==2)
                {
                    sumOfInsertedCoins += inputCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputCoin}");
                }
                //“Nuts”, “Water”, “Crisps”, “Soda”, “Coke”. The prices are: 2.0, 0.7, 1.5, 0.8, 1.0 
            }

            while (true)
            {
                bool isValid = false;
                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Change: {sumOfInsertedCoins:f2}");
                    break;
                }
                else
                {
                    if (input == "Nuts")
                    {
                        price = 2;
                        isValid = true;
                    }
                    else if (input == "Water")
                    {
                        isValid = true;
                        price = 0.7;
                    }
                    else if (input == "Crisps")
                    {
                        isValid = true;
                        price = 1.5;
                    }
                    else if (input == "Soda")
                    {
                        isValid = true;
                        price = 0.8;
                    }
                    else if (input == "Coke")
                    {
                        isValid = true;
                        price = 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }
                    if (isValid)
                    {
                        if (sumOfInsertedCoins-price>=0)
                        {
                            Console.WriteLine($"Purchased {input.ToLower()}");
                            sumOfInsertedCoins -= price;
                            price = 0;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                    }
                }
            }

        }
    }
}
