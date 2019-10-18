using System;

namespace _08_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine()
                .Split();
            var personAndBeerInfo = Console.ReadLine()
                .Split();
            var personAndBankInfo = Console.ReadLine()
                .Split();

            var fullName = personInfo[0] + " " + personInfo[1];
            var adress = personInfo[2];
            var town = personInfo[3];

            var name = personAndBeerInfo[0];
            var beerLitres = int.Parse(personAndBeerInfo[1]);
            var drunk = personAndBeerInfo[2];
            var isDrunk = false;
            if (drunk=="drunk")
            {
                isDrunk = true;
            }

            var namee = personAndBankInfo[0];
            var balance = double.Parse(personAndBankInfo[1]);
            var bankName = personAndBankInfo[2];

            var personInfoThreeuple = new Threeuple<string, string, string>(fullName, adress, town);
            var personAndBeerInfoThreeuple = new Threeuple<string, int, bool>(name, beerLitres, isDrunk);
            var personAndBankInfoThreeuple = new Threeuple<string, double, string>(namee, balance, bankName);

            Console.WriteLine(personInfoThreeuple);
            Console.WriteLine(personAndBeerInfoThreeuple);
            Console.WriteLine(personAndBankInfoThreeuple);
        }
    }
}
