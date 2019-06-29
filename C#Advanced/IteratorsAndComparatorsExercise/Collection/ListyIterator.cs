using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items)
        {
            this.items = items;
            this.index = 0;
        }
        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            if (this.index + 1 < this.items.Count)
            {
                return true;
            }

            return false;
        }
        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var currentItem in this.items)
            {
                yield return currentItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
