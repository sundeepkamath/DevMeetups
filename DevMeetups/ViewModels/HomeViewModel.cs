using DevMeetups.Models;
using System.Collections.Generic;

namespace DevMeetups.ViewModels
{
    public class HomeViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Meetup> UpcomingMeetups { get; set; }
    }
}
