namespace Ferarri
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            var driverName = Console.ReadLine();
            ICar car = new Ferarri(driverName);
            Console.WriteLine(car);

        }
    }
}
