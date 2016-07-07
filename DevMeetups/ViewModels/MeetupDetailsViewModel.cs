using DevMeetups.Models;

namespace DevMeetups.ViewModels
{
    public class MeetupDetailsViewModel
    {
        public Meetup Meetup { get; set; }
        public bool Following { get; set; }
        public bool Attending { get; set; }
    }
}
