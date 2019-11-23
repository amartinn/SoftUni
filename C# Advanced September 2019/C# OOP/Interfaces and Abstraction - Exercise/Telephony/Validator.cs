namespace Telephony
{
    using System.Text.RegularExpressions;
    public static class Validator
    {
        private static Regex regex;
        public static bool ValidateUrl(string url)
        {
            var result = Regex.IsMatch(url,Pattern.UrlPattern);
            return result;
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            var result = Regex.IsMatch(phoneNumber, Pattern.PhoneNumberPattern);
            return result;
        }
    }
}
