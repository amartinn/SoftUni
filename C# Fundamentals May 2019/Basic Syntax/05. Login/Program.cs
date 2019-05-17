using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string pwd = Console.ReadLine();
            string reverse = string.Empty;
            // Console.WriteLine(pwd);
            int count = 0;
            for (int i = pwd.Length; i >0; i--)
            {
                reverse += pwd[i - 1];
               // Console.WriteLine(pwd[i]);
            }
            while (count!=3)
            {
                string newPwd = Console.ReadLine();
                if (newPwd != reverse)
                {
                    count++;
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {pwd} logged in.");
                    return;
                }
                
            }
            Console.WriteLine($"User {pwd} blocked!");

                                          

        }
    }
}
