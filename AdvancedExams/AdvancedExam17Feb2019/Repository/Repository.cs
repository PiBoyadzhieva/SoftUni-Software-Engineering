using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    class Repository
    {
        private Dictionary<int, Person> people;
        private int id;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public void Add(Person person)
        {
            this.people.Add(this.id, person);
            this.id++;
        }

        public Person Get(int id)
        {
            return this.people[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if(!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people[id] = newPerson;
            return true;
        }

        public bool Delete(int id)
        {
            if (!this.people.ContainsKey(id))
            {
                return false;
            }

            this.people.Remove(id);
            return true;
        }
        public int Count => this.people.Count();
    }
}
