using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        private List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.rabbits.Count;
        public void Add(Rabbit rabbit)
        {
            if (this.rabbits.Count < Capacity)
            {
                this.rabbits.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            var rabbitToRemove = rabbits.FirstOrDefault(x => x.Name == name);
            if (rabbitToRemove != null)
            {
                rabbits.Remove(rabbitToRemove);
                return true;
            }
            return false;
        }
        public void RemoveSpecies(string species)
        {
            rabbits = rabbits
                .Where(x => x.Species != species)
                .ToList();
        }
        public Rabbit SellRabbit(string name)
        {
            var rabbitToSell = rabbits.FirstOrDefault(x => x.Name == name);
            var index = rabbits.IndexOf(rabbitToSell);
            rabbits[index].Available = false;
            return rabbitToSell;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitsToSell = rabbits
                .Where(x => x.Species == species)
                .ToArray();

            for (int i = 0; i < rabbitsToSell.Length; i++)
            {
                var currentRabbit = rabbitsToSell[i];
                var index = rabbits.IndexOf(currentRabbit);
                rabbits[index].Available = false;
            }
            return rabbits
              .Where(x => x.Species == species)
              .ToArray();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.rabbits.Where(x=>x.Available==true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
    