namespace Telephony
{
    public class Smartphone : ICaller,IBrowser
    {
        public string Browse(string url) => 
            string.Format(ConstantMessages.PhoneBrowsing, url);

        public string Call(string phoneNumber) =>
            string.Format(ConstantMessages.PhoneCalling, phoneNumber);

    }
}
