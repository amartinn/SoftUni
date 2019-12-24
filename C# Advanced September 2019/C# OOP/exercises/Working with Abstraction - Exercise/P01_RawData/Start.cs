namespace P01_RawData
{
    using CarInfo;
    using Data;
    using Factory;
    using Enums;


    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Start
    {

        private const int tiresCount = 4;
        private CarFactory carFactory;
        private ConsoleDataReader reader;
        private ConsoleDataWriter writer;
        public Start()
        {
            this.carFactory = new CarFactory();
            this.reader = new ConsoleDataReader();
            this.writer = new ConsoleDataWriter();
        }

        public void Run()
        {

            var lines = int.Parse(this.reader.Read());

            CreateCars(lines);
            var command = this.reader.Read();
            CheckCommand(command);

        }

        private void CheckCommand(string command)
        {

            var output = this.carFactory
                .GetCars();

            if (command == nameof(Command.fragile))
            {
                output = output
                    .Where(x => x.Cargo.Type == nameof(Command.fragile) && x.Tires.Any(a => a.Pressure < 1))
                    .ToList();
            }
            else
            {
                output = output
                     .Where(x => x.Cargo.Type == nameof(Command.flammable) && x.Engine.Power > 250)
                     .ToList();
            }
            Print(output);
        }

        private void Print(List<Car> output)
        {
            foreach (var car in output)
            {
                this.writer.Write(car.Model);
            }
        }
        private void CreateCars(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var carParameters = this.reader.Read().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = carParameters[0];

                var engineSpeed = int.Parse(carParameters[1]);
                var enginePower = int.Parse(carParameters[2]);

                var engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(carParameters[3]);
                var cargoType = carParameters[4];

                var cargo = new Cargo(cargoType, cargoWeight);


                var tires = new Tire[tiresCount];
                var count = 0;
                var start = 5;
                var end = 12;
                var increment = 2;
                for (int j = start; j <= end; j += increment)
                {
                    var tirePressure = double.Parse(carParameters[j]);
                    var tireAge = int.Parse(carParameters[j + 1]);
                    var tire = new Tire(tireAge, tirePressure);
                    tires[count] = tire;
                    count++;
                }
                var car = this.carFactory.Create(model, engine, cargo, tires);
                this.carFactory.Add(car);
            }
        }
    }
}
