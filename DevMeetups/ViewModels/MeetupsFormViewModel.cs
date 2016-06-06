using DevMeetups.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevMeetups.ViewModels
{
    public class MeetupsFormViewModel
    {
        [Required]
        public string Topic { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
