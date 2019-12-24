namespace FoodShortage
{
    using Core;
    using System.Collections.Generic;
    public static class Validator
    {
       public static bool ValidateName(string name,IDictionary<string,Citizen> citizens)
        {
            return citizens.ContainsKey(name);
        }
    }
}
