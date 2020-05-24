using System;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split("|")
                .ToList();
            
            var health = 100;
            var coins = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var keyWord = input[i];
                var split = keyWord.Split(" ");
                var key = split[0];
                var attack = int.Parse(split[1]);
                    if (key=="potion")
                    {
                        if (health+attack<100)
                        {
                            Console.WriteLine($"You healed for {attack} hp.");
                            health += attack;

                        }
                        else
                        {
                            Console.WriteLine($"You healed for {Math.Abs(health-100)} hp.");
                            health += Math.Abs(100-health);
                        
                            
                        }
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (key=="chest")
                    {
                        coins += attack;
                        Console.WriteLine($"You found {attack} coins.");
                    }
                    else
                    {
                    if (health-attack>0)
                    {
                        Console.WriteLine($"You slayed {key}.");
                        health -= attack;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {key}.");
                        Console.WriteLine($"Best room: {i+1}");
                        return;
                    }
                    }
                }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {health}");

            }
        }
    }
