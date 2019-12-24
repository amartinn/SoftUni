namespace AquaShop.Core
{
    using Models.Aquariums.Contracts;
    using Models.Decorations.Contracts;
    using Repositories.Contracts;
    using Contracts;
    using Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AquaShop.Repositories;
    using System.Linq;
    using AquaShop.Models.Fish.Contracts;
    using System.Text;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Decorations;

    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType!= "FreshwaterAquarium" && aquariumType!= "SaltwaterAquarium")
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium" )
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
           
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType!= "Ornament" && decorationType!= "Plant")
            {
                throw new InvalidOperationException(
                    ExceptionMessages.InvalidDecorationType);
            }
            IDecoration decoration;
            if (decorationType== "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName,
            string fishType, 
            string fishName, 
            string fishSpecies, 
            decimal price)
        {
            if (fishType!="SaltwaterFish" && fishType!= "FreshwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var temp = fishType.Substring(0, fishType.Length - 4);
            if (!aquarium.GetType().Name.Contains(temp))
            {
                return OutputMessages.UnsuitableWater;
            }
            IFish fish;
            if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            aquarium.AddFish(fish);
            return string.Format(
                OutputMessages.FishAdded,fishType,aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decorationSum = aquarium.Decorations.Sum(x => x.Price);
            var fishSum = aquarium.Fish.Sum(x => x.Price);
            var sum = decorationSum + fishSum;
            return string.Format(
                OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var count = aquarium.Fish.Count;
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, count);

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if ((decorationType != "Ornament" && decorationType != "Plant") || 
                this.decorations.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            var decoration = this.decorations.FindByType(decorationType);
            this.decorations.Remove(decoration);
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            return string.Format(
                OutputMessages.DecorationAdded,decorationType,aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.Append(aquarium.GetInfo());
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
