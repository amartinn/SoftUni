
namespace FoodShortage.Factory.Contracts
{
    using Core;
    public interface ICitizenFactory
    {
        Person Create(string name, int age, string id, string birthdate);
    }
}
