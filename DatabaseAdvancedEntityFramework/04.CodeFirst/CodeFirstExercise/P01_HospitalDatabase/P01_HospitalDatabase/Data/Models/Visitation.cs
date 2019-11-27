namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.Visitation;

    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

    }
}
