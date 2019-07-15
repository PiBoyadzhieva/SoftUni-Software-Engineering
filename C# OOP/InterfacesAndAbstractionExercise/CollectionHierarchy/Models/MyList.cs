using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => base.Data.Count;

        public override string Remove()
        {
            string item = base.Data[0];
            base.Data.RemoveAt(0);
            return item;
        }
    }
}
