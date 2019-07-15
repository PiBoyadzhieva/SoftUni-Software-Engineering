using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public abstract class Collection : IAddCollection
    {
        public Collection()
        {
            Data = new List<string>();
        }
        public List<string> Data { get; }

        public virtual int Add(string item)
        {
            this.Data.Insert(0, item);
            return 0;
        }
    }
}
