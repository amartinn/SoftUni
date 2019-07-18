using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ','\t'},StringSplitOptions.RemoveEmptyEntries);
            var result = 0.0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentInput = input[i];
                
                    var firstLetter = currentInput[0];
                    var lastLetter = currentInput[currentInput.Length - 1];
                    var numberInBetween = double.Parse(currentInput.Substring(1, currentInput.Length-2));
                if (char.IsUpper(firstLetter))
                {
                    numberInBetween /= firstLetter - 'A' + 1;
                }
                else
                {
                    numberInBetween *= firstLetter - 'a' + 1;
                }
                if (char.IsUpper(lastLetter))
                {
                    numberInBetween -= lastLetter - 'A' + 1;
                }
                else
                {
                    numberInBetween += lastLetter - 'a' + 1;
                }
                result += numberInBetween;
            }
            Console.WriteLine(result.ToString("f2"));

        }
    }
}
