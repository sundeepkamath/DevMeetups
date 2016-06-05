using DevMeetups.Models;
using DevMeetups.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Create(MeetupsFormViewModel viewModel)
        {
            var categoryId = _context.Categories.Single(c => c.Id == viewModel.Category);

            var meetup = new Meetup
            {
                Topic = viewModel.Topic,
                Venue = viewModel.Venue,
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                DeveloperId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category
            };

            _context.Meetups.Add(meetup);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
