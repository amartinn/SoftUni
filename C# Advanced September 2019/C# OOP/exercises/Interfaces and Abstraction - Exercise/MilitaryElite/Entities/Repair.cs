namespace MilitaryElite.Entities
{
    using Contracts;
    class Repair : IRepair
    {
        public Repair(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }

        public string Name { get; }

        public int HoursWorked { get; }
        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
