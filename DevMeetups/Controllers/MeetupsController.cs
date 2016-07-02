using DevMeetups.Models;
using DevMeetups.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DevMeetups.Controllers
{
    public class MeetupsController : Controller
    {
        private readonly ApplicationDbContext _context = null;

        public MeetupsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var myMeetups = _context.Meetups
                            .Where(m => m.DeveloperId == userId && m.DateTime > DateTime.Now)
                            .Include(m => m.Category)
                            .ToList();

            return View(myMeetups);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetupsFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetupsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }

            var meetup = new Meetup
            {
                Topic = viewModel.Topic,
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime(),
                DeveloperId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category
            };

            _context.Meetups.Add(meetup);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Meetups");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var meetups = _context.Attendances
                                .Where(a => a.AttendeeId == userId)
                                .Select(a => a.Meetup)
                                .Include(m => m.Developer)
                                .Include(m => m.Category)
                                .ToList();

            var meetupsViewModel = new MeetupsViewModel
            {
                UpcomingMeetups = meetups,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Meetups I'm going"
            };

            return View("Meetups", meetupsViewModel);
        }
    }
}
