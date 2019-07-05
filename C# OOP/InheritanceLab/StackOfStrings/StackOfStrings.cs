using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(params string[] data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
