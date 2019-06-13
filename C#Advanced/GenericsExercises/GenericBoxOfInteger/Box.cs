﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    class Box<T>
    {
        private T Item;

        public Box(T item)
        {
            this.Item = item;
        }

        public override string ToString()
        {
            return $"{Item.GetType()}: {Item}";
        }
    }
}
