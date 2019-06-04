using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAgeTwoWay
{
    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] currentPerson = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var person = new Person
                {
                    Name = currentPerson[0],
                    Age = int.Parse(currentPerson[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterPredicate;

            if(condition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else
            {
                filterPredicate = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> selectFunc;

            if(format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else
            {
                selectFunc = p => $"{p.Name}";
            }

            people
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
