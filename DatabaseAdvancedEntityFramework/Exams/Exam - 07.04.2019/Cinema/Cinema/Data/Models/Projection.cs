namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection
    {
        public int Id { get; set; }

        [Required]
        public int MovieId  { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int HallId  { get; set; }

        [Required]
        public Hall Hall { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
