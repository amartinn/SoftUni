using System;
namespace _05.Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int leftsum = 0;
            int rightsum = 0;
            for (int i = start; i <= end; i++)
            {
                int current = i;
                int fifthDigit = current % 10;
                current = (current - fifthDigit) / 10;
                int forthDigit = current % 10;
                current = (current - forthDigit) / 10;
                int thirdDigit = current % 10;
                current = (current - thirdDigit) / 10;
                int secondDigit = current % 10;
                current = (current - secondDigit) / 10;
                int firstDigit = current % 10;
                current = (current - firstDigit) / 10;
                rightsum = fifthDigit + forthDigit;
                leftsum = firstDigit + secondDigit;
                if (rightsum == leftsum)
                {
                    Console.Write(i + " ");
                    continue;
                }
                else
                {
                    if (rightsum > leftsum)
                    {
                        leftsum += thirdDigit;
                    }
                    else if (leftsum > rightsum)
                    {
                        rightsum += thirdDigit;
                    }
                }
                if (rightsum == leftsum)
                {
                    Console.Write(i + " ");
                    continue;
                }
                leftsum = 0;
                rightsum = 0;
            }
        }
    }
}
