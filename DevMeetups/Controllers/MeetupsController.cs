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
        public ActionResult Edit(int meetupId)
        {
            var userId = User.Identity.GetUserId();

            var meetupData = _context.Meetups.Single(m => m.Id == meetupId && m.DeveloperId == userId);

            var viewModel = new MeetupsFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Category = meetupData.CategoryId,
                Date = meetupData.DateTime.ToString("d MMM yyyy"),
                Time = meetupData.DateTime.ToString("HH:mm"),
                Topic = meetupData.Topic,
                Venue = meetupData.Venue,
                Heading = "Edit a meetup",
                Id = meetupData.Id
            };
            return View("MeetupForm", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MeetupsFormViewModel
            {
                Heading = "Add a Meetup",
                Categories = _context.Categories.ToList()
            };
            return View("MeetupForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetupsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("MeetupForm", viewModel);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MeetupsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("MeetupForm", viewModel);
            }

            var userId = User.Identity.GetUserId();

            var meetup = _context.Meetups.Single(m => m.Id == viewModel.Id && m.DeveloperId == userId);
            meetup.Topic = viewModel.Topic;
            meetup.Venue = viewModel.Venue;
            meetup.CategoryId = viewModel.Category;
            meetup.DateTime = viewModel.GetDateTime();


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
