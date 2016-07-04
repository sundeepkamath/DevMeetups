using DevMeetups.Models;
using DevMeetups.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DevMeetups.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {
            var meetups = _context.Meetups
                .Include(m => m.Developer)
                .Include(m => m.Category)
                .Where(m => m.DateTime > DateTime.Now && !m.IsCancelled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                meetups = meetups.Where(m =>
                                    m.Developer.Name.Contains(query) ||
                                    m.Category.Name.Contains(query) ||
                                    m.Venue.Contains(query) ||
                                    m.Topic.Contains(query));
            }

            var viewModel = new MeetupsViewModel
            {
                UpcomingMeetups = meetups,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Meetups",
                SearchTerm = query
            };

            return View("Meetups", viewModel);
        }

        [HttpPost]
        public ActionResult Search(MeetupsViewModel meetupsViewModel)
        {
            return RedirectToAction("Index", "Home", new { query = meetupsViewModel.SearchTerm });
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}