using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numcopy = num;
            int sum = 1;
            string strNum = num.ToString();
            int count = 0;
            int digitSum = 0;
            while (true)
            {
                int digit = num % 10;
                num /= 10;
                for (int i = 1; i <=digit; i++)
                {
                    sum *= i;
                }
                digitSum += sum;
                
                if (count==strNum.Length)
                {
                    digitSum -= 1;
                    if (digitSum==numcopy)
                    {
                        Console.WriteLine("yes");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("no");
                        return;
                    }
                }
                sum = 1;
                count++;
                
            }
        }
    }
}
