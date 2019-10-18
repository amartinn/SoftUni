using System;
using System.Collections.Generic;
namespace _04_
{
    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public Box(List<T> values)
            : this()
        {
            this.Values.AddRange(values);
        }
        public List<T> Values { get; set; }
        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = temp;
        }
        public void PrintList()
        {
            foreach (var word in this.Values)
            {
                Console.WriteLine($"{word.GetType()}: {word}");
            }
        }
    }
}
