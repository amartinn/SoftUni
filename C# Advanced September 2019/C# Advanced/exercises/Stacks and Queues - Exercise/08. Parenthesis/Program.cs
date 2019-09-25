using System;

namespace _08._Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input.Length%2!=0)
            {
                Console.WriteLine("NO");
                return;
            }
            bool isThereOpenParenthesis = false;
            var lastOpenParenthesisIndex = -1;
            var openParenthesis = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                while (input[i]=='[' || input[i]=='{' || input[i]=='(')
                {
                    lastOpenParenthesisIndex = i;
                    isThereOpenParenthesis = true;
                }
            }
           
        }
    }
}
