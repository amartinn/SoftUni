

using System;

namespace DefiningClasses
{
   public static class DateModifier
    {
        public static int DifferenceBetweenTwoDates(string startDate,string endDate)
        {
            DateTime fistDate = DateTime.Parse(startDate);
            DateTime secondDate = DateTime.Parse(endDate);
            var difference = Math.Abs((int)(fistDate - secondDate).TotalDays);
            return difference;
        }
    }
}
