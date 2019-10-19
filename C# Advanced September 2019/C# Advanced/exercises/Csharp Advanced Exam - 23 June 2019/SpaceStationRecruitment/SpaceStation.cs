using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;
        private string name;
        private int capacity;
       

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count => this.astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.capacity>this.astronauts.Count)
            {
                this.astronauts.Add(astronaut);
            }
        }
        public bool Remove(string name)
        {
            var astronaultToRemove = this.astronauts.FirstOrDefault(x => x.Name == name);
            if (astronaultToRemove != null)
            {
                this.astronauts.Remove(astronaultToRemove);
                return true;
            }
            return false;
        }
        public Astronaut GetOldestAstronaut()
        {
            var oldestAstronautAge = this.astronauts.Max(x => x.Age);
            var oldestAstronaut = this.astronauts.FirstOrDefault(x => x.Age == oldestAstronautAge);
            return oldestAstronaut;
        }
        public Astronaut GetAstronaut(string name)
        {
            var astronautToSearch = this.astronauts.FirstOrDefault(x => x.Name == name);
            if (astronautToSearch!=null)
            {
                return astronautToSearch;
            }
            return null;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            foreach (var astronaut in this.astronauts)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString();
        }
    }
}
