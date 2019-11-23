namespace Encapsulation
{
    using System;

    public class Program
    {
        public static void Main()
        {

            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var box = new Box(length, width, height);
            Console.WriteLine(box.ToString());
        }
    }
}
