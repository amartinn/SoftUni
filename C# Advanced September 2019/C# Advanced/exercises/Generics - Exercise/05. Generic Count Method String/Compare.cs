using System;
using System.Collections.Generic;
namespace _05_
{
    public static  class Compare
    {
        public static int GreaterValue<T>(this List<T> items, T targetItem)
            where T:IComparable
        {
            var counter = 0;
            foreach (var value in items)
            {
                if (value.CompareTo(targetItem)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
