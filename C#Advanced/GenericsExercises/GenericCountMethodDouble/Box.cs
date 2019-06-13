using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public List<T> Data
        {
            get  { return this.data; }
            private set { this.data = value; }
        }

        public void Add(T item)
        {
            this.data.Add(item);
        }
    }
}
