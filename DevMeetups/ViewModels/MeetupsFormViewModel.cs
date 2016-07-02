using DevMeetups.Controllers;
using DevMeetups.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DevMeetups.ViewModels
{
    public class MeetupsFormViewModel
    {
        public int Id { get; set; }

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

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MeetupsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<MeetupsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
