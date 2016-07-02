using System;
using System.ComponentModel.DataAnnotations;

namespace DevMeetups.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        public bool IsCancelled { get; set; }

        public ApplicationUser Developer { get; set; }

        [Required]
        public string DeveloperId { get; set; }

        [Required]
        [StringLength(255)]
        public string Topic { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public byte CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}
