using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }
        public void AddMember (Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = familyMembers
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestPerson;
        }
    }
}
