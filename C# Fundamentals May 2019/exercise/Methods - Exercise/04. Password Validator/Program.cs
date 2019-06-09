using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckForValidPassword();
        }
        static void CheckForValidPassword()
        {
            var pwd = Console.ReadLine();
            printResult(pwd);
        }
        static bool CharCount(string pwd)
        {
            if (pwd.Length<6 || pwd.Length>10)
            {
                return false;
            }
                return true;
        }
        static bool IsItLetterOrDigit(string pwd)
        {
            for (int i = 0; i < pwd.Length; i++)
            {
                if (char.IsDigit(pwd[i]) || char.IsLetter(pwd[i]))
                {
                }
                else
                {
                    return false;
                }    
            }
            return true;
        }
        static bool isThereTwoDigits(string pwd)
        {
            var countDigits = 0;
            for (int i = 0; i < pwd.Length; i++)
            {
                if (char.IsDigit(pwd[i]))
                {
                    countDigits++;
                }
            }
            if (countDigits<2)
            {
                return false;
            }
            return true;
        }
        static void printResult(string pwd)
        {
            if (CharCount(pwd) && IsItLetterOrDigit(pwd) && isThereTwoDigits(pwd))
            {
                Console.WriteLine("Password is valid");
                return;

            }
             if (!CharCount(pwd))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!IsItLetterOrDigit(pwd))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!isThereTwoDigits(pwd))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
    }
}
