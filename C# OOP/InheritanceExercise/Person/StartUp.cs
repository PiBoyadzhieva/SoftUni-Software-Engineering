using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if(age >= 0 && age <= 15)
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }

            else if (age > 15)
            {
                Person person = new Person(name, age);
                Console.WriteLine(person);
            }
        }
    }
}