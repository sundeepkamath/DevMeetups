using DevMeetups.Models;
using System.Collections.Generic;

namespace DevMeetups.ViewModels
{
    public class MeetupsViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Meetup> UpcomingMeetups { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}
