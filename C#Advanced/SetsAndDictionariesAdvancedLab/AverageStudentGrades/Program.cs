using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    public class Program
    {
        public static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] entry = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(students.ContainsKey(entry[0]))
                {
                    students[entry[0]].Add(double.Parse(entry[1]));
                }
                else
                {
                    students[entry[0]] = new List<double>()
                    {
                        double.Parse(entry[1])
                    };
                }
            }

            foreach (var kvp in students)
            {
                string name = kvp.Key;
                List<double> studentGrades = kvp.Value;
                double average = kvp.Value.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in studentGrades )
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
