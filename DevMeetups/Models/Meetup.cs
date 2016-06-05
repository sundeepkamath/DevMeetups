using System;

namespace DevMeetups.Models
{
    public class Meetup
    {
        public int Id { get; set; }
        public ApplicationUser Developer { get; set; }
        public string Topic { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Category Category { get; set; }
    }
}
