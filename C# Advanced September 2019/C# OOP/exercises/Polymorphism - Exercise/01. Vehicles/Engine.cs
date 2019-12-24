namespace Vehicles
{
    using IO;
    using Core;
    using Factory;
    using Constants;

    using System;
    using System.Reflection;
    class Engine : IEngine
    {
        public void Run(VehicleFactory factory, IConsoleWriter writer, IConsoleReader reader)
        {
            var carInfo = reader.ReadLine().Split();
            var carName = carInfo[0];
            var carFuelQuantity = double.Parse(carInfo[1]);
            var carLitresPerKm = double.Parse(carInfo[2]);
            var carTankCapacity = int.Parse(carInfo[3]);
            Vehicle car = factory.Create(carName, carFuelQuantity, carLitresPerKm, carTankCapacity);


            var truckInfo = reader.ReadLine().Split();
            var truckName = truckInfo[0];
            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckLitresPerKm = double.Parse(truckInfo[2]);
            var truckTankCapacity = int.Parse(truckInfo[3]);
            Vehicle truck = factory.Create(truckName, truckFuelQuantity, truckLitresPerKm, truckTankCapacity);

            var busInfo = reader.ReadLine().Split();
            var busName = busInfo[0];
            var busFuelQuantity = double.Parse(busInfo[1]);
            var busLitresPerKm = double.Parse(busInfo[2]);
            var busTankCapacity = int.Parse(busInfo[3]);
            Bus bus = factory.Create(busName, busFuelQuantity, busLitresPerKm, busTankCapacity) as Bus;

            var numberOfCommands = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = reader.ReadLine().Split();
                var commandType = command[0];
                var vehicleName = command[1];
                var vehicleType = Type.GetType($"{typeof(StartUp).Namespace}.Core.{vehicleName}");

                Vehicle vehicle = car.GetType().Name == vehicleType.Name ? car : 
                    truck.GetType().Name == vehicleType.Name ? truck : bus;

                var isBusEmpty = commandType == ConstantMessages.DriveEmpty;
                if (vehicle is Bus)
                {
                    if (isBusEmpty)
                    {
                        bus.HasPeople = false;
                        commandType = ConstantMessages.DriveMethodName;
                    }
                 
                }
                if (commandType == ConstantMessages.DriveMethodName)
                    {
                    var distance = double.Parse(command[2]);
                    var message = string.Empty;
                    try
                    {
                        message = Drive(distance, vehicleType, vehicle);
                    }
                    catch (Exception ex )
                    {
                        writer.WriteLine(ex.InnerException.Message);

                    }
                    if (message!=null)
                    {
                        writer.WriteLine(message);
                    }
                  
                }
                else
                {
                    var fuel = double.Parse(command[2]);
                    try
                    {
                        vehicleType.GetMethod(ConstantMessages.RefuelMethodName,
                                     BindingFlags.Public | BindingFlags.Instance)
                                       .Invoke(vehicle, new object[] { fuel });
                    }
                    catch (Exception ex)
                    {

                        writer.WriteLine(ex.InnerException.Message);
                    }


                }
            }
            writer.WriteLine(car);
            writer.WriteLine(truck);
            writer.WriteLine(bus);
        }

        private string Drive(double distance, Type vehicleType, Vehicle vehicle)
        {
            var method = vehicleType.GetMethod(ConstantMessages.DriveMethodName,
        BindingFlags.Public | BindingFlags.Instance);
            var message = method.Invoke(vehicle, new object[] { distance });
            return (string)message;
        }
    }
}
