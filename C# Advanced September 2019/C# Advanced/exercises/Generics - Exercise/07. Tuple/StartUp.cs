using System;
using System.Text;

namespace _07_
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var result = new StringBuilder();


            var nameAndAdress = Console.ReadLine()
                .Split(' ');
            var nameAndBeerLitres = Console.ReadLine()
                .Split(' ');
            var intAndDouble = Console.ReadLine()
                .Split(' ');


      

            var firstName = nameAndAdress[0];
            var secondName = nameAndAdress[1];
            var fullName = firstName + " " + secondName;
            var adress = nameAndAdress[2];

            var name = nameAndBeerLitres[0];
            var beerLitres = double.Parse(nameAndBeerLitres[1]);

            var @int = int.Parse(intAndDouble[0]);
            var @double = double.Parse(intAndDouble[1]);

            var personInfo = new MyTuple<string,string>(fullName,adress);
            var personBeerInfo = new MyTuple<string, double>(name, beerLitres);
            var numbersInfo = new Tuple<int, double>(@int, @double);


            Console.WriteLine(personInfo.ToString());
            Console.WriteLine(personBeerInfo.ToString());
            Console.WriteLine($"{numbersInfo.Item1} -> {numbersInfo.Item2}");
        }
    }
}
