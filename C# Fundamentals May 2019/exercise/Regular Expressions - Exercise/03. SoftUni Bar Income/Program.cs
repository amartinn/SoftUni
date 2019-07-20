using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"%([A-Z][a-z]+)%(?:[^|$.%]*)<(\w+)>(?:[^|$.%\d]*)\|(\d+)\|(?:[^$.%\d]*)([0-9.]+)\$";
            var regex = new Regex(pattern);
            var input = string.Empty;
            var total = 0.0;
            while ((input=Console.ReadLine())!="end of shift")
            {
                var match = regex.Match(input);
                if (match.Success)
                {

                    var currentName = match.Groups[1].Value;
                    var currentProduct = match.Groups[2].Value;
                    var quantityOfTheProduct = int.Parse(match.Groups[3].Value);
                    var priceOfTheProduct = double.Parse(match.Groups[4].Value);
                    var currentTotalPrice = priceOfTheProduct * quantityOfTheProduct;
                    total += currentTotalPrice;
                    Console.WriteLine($"{currentName}: {currentProduct} - {currentTotalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {total:f2}");

        }
    }
}
