using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentAcademy
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var studentGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<double>());
                }

                studentGrades[name].Add(grade);
            }

            var fillteredStudentGrades = studentGrades
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in fillteredStudentGrades)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;

                Console.WriteLine($"{name} -> {grades.Average():f2}");
            }   
        }
    }
}
