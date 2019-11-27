namespace CodeFirst.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataValidations.Students;
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FisrtName { get; set; }


        [MaxLength(NameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public bool HasScholarship { get; set; }

        public DateTime RegistrationDate { get; set; }

        public StudentType Type { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<StudentInCourse> Courses { get; set; } = new HashSet<StudentInCourse>();

        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();

        [NotMapped]
        public string FullName
        {
            get
            {
                if(this.MiddleName == null)
                {
                    return $"{this.FisrtName} {this.LastName})";
                }

                return $"{this.FisrtName} {this.MiddleName} {this.LastName})";
            }
        }
    }
}
