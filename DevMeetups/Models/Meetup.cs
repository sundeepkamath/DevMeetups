using System;
using System.ComponentModel.DataAnnotations;

namespace DevMeetups.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Developer { get; set; }

        [Required]
        [StringLength(255)]
        public string Topic { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
