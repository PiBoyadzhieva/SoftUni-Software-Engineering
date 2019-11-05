namespace CodeFirst
{
    using CodeFirst.Data;
    using CodeFirst.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new StudentDbContext();

            db.Database.Migrate();

            //--
            //db.StudentsInCourses.Add(new StudentInCourse
            //{
            //    Student = new Student
            //    {
            //        FisrtName = "Name",
            //        LastName = "Peshov",
            //        RegistrationDate = DateTime.UtcNow,
            //        Type = StudentType.Graduated,
            //        Town = new Town
            //        {
            //            Name = "Plovdiv"
            //        }
            //    },
            //    Course = new Course
            //    {
            //        Name = "C# OOP",
            //        Description = "Interfaces, Delegate"
            //    }
            //});

            //db.SaveChanges();


            //--
            //var course = new Course
            //{
            //    Name = "ASP.NET",
            //    Description = "ASP.NET MVC"
            //};

            //db.Add(course);
            //db.SaveChanges();

            //var studentId = db.Students
            //    .Select(st => st.Id)
            //    .FirstOrDefault();

            //db.StudentsInCourses.Add(new StudentInCourse
            //{
            //    StudentId = studentId,
            //    CourseId = course.Id
            //});
            //db.SaveChanges();


            //--
            //query
            //var cources = db.Courses
            //    .Select(c => new
            //    {
            //        c.Name,
            //        TotalStudents = c
            //            .Students
            //            .Where(st => st.Course.Homeworks.Average(h => h.Score) > 2)
            //            .Count(),
            //        Student = c
            //            .Students
            //            .Select(st => new
            //            {
            //                FullName = st.Student.FisrtName + " " + st.Student.LastName,
            //                Score = st.Student.Homeworks.Average(h => h.Score)
            //            })
            //    })
            //    .ToList();
            //Console.WriteLine(cources.Count());
        }
    }
}
