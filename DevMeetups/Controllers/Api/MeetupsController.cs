﻿using DevMeetups.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace DevMeetups.Controllers.Api
{
    [Authorize]
    public class MeetupsController : ApiController
    {
        private ApplicationDbContext _context;

        public MeetupsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var meetup = _context.Meetups
                                .Include(m => m.Attendances.Select(a => a.Attendee))
                                .Single(m => m.Id == id && m.DeveloperId == userId);

            if (meetup.IsCancelled)
                return NotFound();

            meetup.Cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}