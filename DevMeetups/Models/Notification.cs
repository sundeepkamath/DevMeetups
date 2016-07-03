using System;
using System.ComponentModel.DataAnnotations;

namespace DevMeetups.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public NotificationType NotificationType { get; private set; }

        public DateTime DateTime { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }

        [Required]
        public Meetup Meetup { get; private set; }

        protected Notification()
        {

        }

        private Notification(Meetup meetup, NotificationType notificationType)
        {
            if (meetup == null)
                throw new ArgumentNullException("meetup");

            Meetup = meetup;
            NotificationType = notificationType;
            DateTime = DateTime.Now;
        }

        public static Notification MeetupCreated(Meetup meetup)
        {
            return new Notification(meetup, NotificationType.MeetupAdded);
        }

        public static Notification MeetupUpdated(Meetup newMeetup, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(newMeetup, NotificationType.MeetupUpdated);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification MeetupCancelled(Meetup meetup)
        {
            return new Notification(meetup, NotificationType.MeetupCancelled);
        }
    }
}
