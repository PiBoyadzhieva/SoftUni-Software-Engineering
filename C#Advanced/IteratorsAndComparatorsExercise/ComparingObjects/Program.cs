using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var personInfo = input.Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                var person = new Person(name, age, town);

                people.Add(person);

                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine());

            int countOfMatches = 0;
            int countOfNotEqualPeople = 0;

            var targetPerson = people[personIndex - 1];

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfMatches > 1)
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
