namespace Vehicles.Factory
{
    using Vehicles.Core;
    using System;
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle Create(string type, double fuel, double distance,int capacity)
        {
           Vehicle vehicle = Activator
                .CreateInstance(Type.GetType(typeof(StartUp).Namespace + ".Core." + type)
                ,new object[] { fuel, distance,capacity }) as Vehicle;
            return vehicle;
        }
    }
}
