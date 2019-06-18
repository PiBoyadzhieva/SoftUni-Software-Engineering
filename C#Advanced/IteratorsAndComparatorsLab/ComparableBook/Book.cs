using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public int CompareTo(Book other)
        {
            var yearCompare = this.Year.CompareTo(other.Year);

            if(yearCompare == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return yearCompare;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
