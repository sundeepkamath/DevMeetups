using DevMeetups.Models;
using System.Collections.Generic;

namespace DevMeetups.ViewModels
{
    public class MeetupsFormViewModel
    {
        public string Topic { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Category { get; set; }
        public IEnumerable<Category> Categories { get; set;}
    }
}
