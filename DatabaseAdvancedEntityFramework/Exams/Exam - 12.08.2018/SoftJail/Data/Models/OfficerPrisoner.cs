namespace SoftJail.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OfficerPrisoner
    {
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }

        public int OfficerId { get; set; }

        public Officer Officer { get; set; }
    }
}