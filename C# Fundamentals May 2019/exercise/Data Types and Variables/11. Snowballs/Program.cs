using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = long.Parse(Console.ReadLine());
            BigInteger snowballValue = long.MinValue;
            BigInteger currentSnowballSnow = 0;
            BigInteger currentSnowballTime = 0;
            BigInteger currentSnowballQuality = 0;
            for (int i = 0; i < n; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballQuality = BigInteger.Parse(Console.ReadLine());
                BigInteger currentValue = BigInteger.Pow(snowballSnow / snowballTime,(int) snowballQuality);
                if (currentValue > snowballValue)
                {
                    snowballValue = currentValue;
                    currentSnowballQuality = snowballQuality;
                    currentSnowballTime = snowballTime;
                    currentSnowballSnow = snowballSnow;
                }

            }
            Console.WriteLine($"{currentSnowballSnow} : {currentSnowballTime} = {snowballValue} ({currentSnowballQuality})");
        }


    }
}
