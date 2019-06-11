using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int familyMembersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < familyMembersCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string memberName = input[0];
                int memberAge = int.Parse(input[1]);

                Person member = new Person(memberName, memberAge);

                family.AddMember(member);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
