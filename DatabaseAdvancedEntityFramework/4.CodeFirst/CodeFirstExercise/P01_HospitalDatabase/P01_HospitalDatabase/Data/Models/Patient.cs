namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataValidations.Patient;

    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(AdressMaxLength)]
        public string Address { get; set; }

        [MaxLength(EmailMaxLength)]
        //[Column(TypeName = "varchar"(80))]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();

        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
