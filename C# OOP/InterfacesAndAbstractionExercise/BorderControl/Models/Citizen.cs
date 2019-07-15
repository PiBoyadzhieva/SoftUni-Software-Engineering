using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : Entered
    {
        public Citizen(string name, int age, string id) 
            : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
