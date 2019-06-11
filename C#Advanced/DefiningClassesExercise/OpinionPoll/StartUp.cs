using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfPerson = int.Parse(Console.ReadLine());
            List<Person> family = new List<Person>();

            for (int i = 0; i < numberOfPerson; i++)
            {
                string[] input = Console.ReadLine().Split();
                string nameOfPerson = input[0];
                int ageOfPerson = int.Parse(input[1]);

                family.Add(new Person(nameOfPerson, ageOfPerson));
            }

            List<Person> sortedFamily = family
                .Where(a => a.Age > 30)
                .OrderBy(n => n.Name)
                .ToList();

            foreach (var person in sortedFamily)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
