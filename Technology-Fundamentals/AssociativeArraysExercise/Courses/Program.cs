using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> courseStudents = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "end")
                {
                    break;
                }

                string[] tokens = command.Split(" : ");
                string course = tokens[0];
                string student = tokens[1];

                if(!courseStudents.ContainsKey(course))
                {
                    courseStudents.Add(course, new List<string>());
                }

                courseStudents[course].Add(student);
            }

            foreach (var kvp in courseStudents.OrderByDescending(x => x.Value.Count))
            {
                List<string> students = kvp.Value;

                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var item in students.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
