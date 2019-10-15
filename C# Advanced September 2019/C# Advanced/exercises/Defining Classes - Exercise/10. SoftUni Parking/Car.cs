using System;
namespace SoftUniParking
{
    public class Car
    {

        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public override string ToString()
        {
            return $"Make: {this.make}" + Environment.NewLine +
                   $"Model: {this.model}" + Environment.NewLine +
                   $"HorsePower: {this.horsePower}" + Environment.NewLine +
                   $"RegistrationNumber: {this.registrationNumber}";

        }

    }
}
