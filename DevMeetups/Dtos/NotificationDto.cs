using DevMeetups.Models;
using System;

namespace DevMeetups.Dtos
{
    public class NotificationDto
    {
        public NotificationType NotificationType { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public MeetupDto Meetup { get; set; }
    }
}