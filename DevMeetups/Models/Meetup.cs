using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DevMeetups.Models
{
    public class Meetup
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

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

        public ICollection<Attendance> Attendances { get; private set; }

        internal void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.MeetupCancelled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public Meetup()
        {
            Attendances = new Collection<Attendance>();
        }

        internal void Update(Meetup newMeetup)
        {
            var notification = Notification.MeetupUpdated(this, DateTime, Venue);

            Topic = newMeetup.Topic;
            Venue = newMeetup.Venue;
            Category = newMeetup.Category;
            DateTime = newMeetup.DateTime;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}
