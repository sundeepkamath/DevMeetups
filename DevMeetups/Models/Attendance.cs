using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevMeetups.Models
{
    public class Attendance
    {
        public Meetup Meetup { get; set; }
        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order =1)]
        public int MeetupId { get; set; }

        [Key]
        [Column(Order =2)]
        public string AttendeeId { get; set; }
    }
}
