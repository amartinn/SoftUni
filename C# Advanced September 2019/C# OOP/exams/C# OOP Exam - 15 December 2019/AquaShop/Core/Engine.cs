namespace AquaShop.Core
{
    using IO;
    using IO.Contracts;
    using Contracts;

    using System;
    using System.Reflection;



    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                string result = string.Empty;

                if (input[0] == "AddAquarium")
                {
                    string aquariumType = input[1];
                    string aquariumName = input[2];

                    result = controller.AddAquarium(aquariumType, aquariumName);
                }
                else if (input[0] == "AddDecoration")
                {
                    string decorationType = input[1];

                    result = controller.AddDecoration(decorationType);
                }
                else if (input[0] == "InsertDecoration")
                {
                    var aquariumName = input[1];
                    var decorationType = input[2];

                    result = controller.InsertDecoration(aquariumName, decorationType);
                }
                else if (input[0] == "AddFish")
                {
                    var aquariumName = input[1];
                    var fishType = input[2];
                    var fishName = input[3];
                    var fishSpecies = input[4];
                    var price = decimal.Parse(input[5]);

                    result = controller.AddFish(aquariumName, fishType, fishName, fishSpecies, price);
                }
                else if (input[0] == "FeedFish")
                {
                    var aquariumName = input[1];

                    result = controller.FeedFish(aquariumName);
                }
                else if (input[0] == "CalculateValue")
                {
                    var aquariumName = input[1];

                    result = controller.CalculateValue(aquariumName);
                }
                else if (input[0] == "Report")
                {
                    result = controller.Report();
                }

                writer.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    writer.WriteLine(ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
               
            }
        }
    }
}
