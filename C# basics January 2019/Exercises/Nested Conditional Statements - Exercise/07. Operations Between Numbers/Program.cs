using System;
namespace _07.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            char operatoR = char.Parse(Console.ReadLine());
            double result = 0;
            if (n2 == 0 && (operatoR == '/' || operatoR == '%'))
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                return;
            }
            switch (operatoR)
            {
                case '+':
                    {
                        result = n1 + n2;
                        break;
                    }
                case '-':
                    {
                        result = n1 - n2;
                        break;
                    }
                case '*':
                    {
                        result = n1 * n2;
                        break;
                    }
                case '/':
                    {
                        result = n1 / n2;
                        break;
                    }
                case '%':
                    {
                        result = n1 % n2;
                        break;
                    }
            }
            if (result % 2 == 0 && (operatoR == '+' || operatoR == '-' || operatoR == '*'))
            {
                Console.WriteLine($"{n1} {operatoR} {n2} = {result} - even");
            }
            else if ((result % 2 != 0 && (operatoR == '+' || operatoR == '-' || operatoR == '*')))
            {
                Console.WriteLine($"{n1} {operatoR} {n2} = {result} - odd");
            }
            else if (operatoR == '/')
            {
                Console.WriteLine($"{n1} / {n2} = {result:f2}");
            }
            else if (operatoR == '%')
            {
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
        }
    }
}
