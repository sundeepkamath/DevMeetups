using System;

namespace DevMeetups.Dtos
{
    public class MeetupDto
    {
        public int Id { get; set; }
        public bool IsCancelled { get; set; }
        public UserDto Developer { get; set; }
        public string Topic { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public CategoryDto Category { get; set; }
    }
}