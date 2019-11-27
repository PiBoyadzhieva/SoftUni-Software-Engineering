namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;

    using static DataValidations.Diagnose;

    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(DiagnoseMaxName)]
        public string Name { get; set; }

        [MaxLength(CommentsMaxLength)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
