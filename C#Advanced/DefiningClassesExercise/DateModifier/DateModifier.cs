using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            this.SecondDate = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        }
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public int Difference()
        {
            TimeSpan difference = FirstDate - SecondDate;
            return Math.Abs(difference.Days);
        }
    }
}
