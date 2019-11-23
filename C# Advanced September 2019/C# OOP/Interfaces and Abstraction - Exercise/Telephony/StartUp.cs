using System;
namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var Urls = Console.ReadLine().Split();
            var phone = new Smartphone();
            foreach (var phoneNumber in phoneNumbers)
            {
                if (Validator.ValidatePhoneNumber(phoneNumber))
                {
                    Console.WriteLine(ConstantMessages.InvalidPhoneNumber);
                    continue;
                }

                Console.WriteLine(phone.Call(phoneNumber));
            }
            foreach (var url in Urls)
            {
                if (Validator.ValidateUrl(url))
                {
                    Console.WriteLine(ConstantMessages.InvalidURl);
                    continue;
                }
                Console.WriteLine(phone.Browse(url));
            }
        }   
    }
}
