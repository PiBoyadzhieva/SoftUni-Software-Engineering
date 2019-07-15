using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public void Run()
        {
            string[] items = Console.ReadLine()
                .Split();

            List<int> result = new List<int>();

            for (int i = 1; i <= 3; i++)
            {
                foreach (var item in items)
                {
                    if(i == 1)
                    {
                        result.Add(addCollection.Add(item));
                    }
                    else if(i == 2)
                    {
                        result.Add(addRemoveCollection.Add(item));
                    }
                    else if(i == 3)
                    {
                        result.Add(myList.Add(item));
                    }
                }

                Console.WriteLine(string.Join(" ", result));
                result.Clear();
            }

            int itemsToRemove = int.Parse(Console.ReadLine());

            RemoveItem(itemsToRemove, addRemoveCollection);
            RemoveItem(itemsToRemove, myList);
        }

        private static void RemoveItem(int items, IAddRemoveCollection collection)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < items; i++)
            {
                result.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
