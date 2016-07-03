using System;
using System.ComponentModel.DataAnnotations;

namespace DevMeetups.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public NotificationType NotificationType { get; private set; }

        public DateTime DateTime { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Meetup Meetup { get; private set; }

        protected Notification()
        {

        }

        public Notification(Meetup meetup, NotificationType notificationType)
        {
            if (meetup == null)
                throw new ArgumentNullException("meetup");

            Meetup = meetup;
            NotificationType = notificationType;
            DateTime = DateTime.Now;
        }
    }
}
