namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car(300, 200);
            var veh = new Vehicle(300, 200);
            car.Drive(10);
            veh.Drive(10);
            System.Console.WriteLine(car.Fuel);
            System.Console.WriteLine(veh.Fuel);
        }
    }
}
