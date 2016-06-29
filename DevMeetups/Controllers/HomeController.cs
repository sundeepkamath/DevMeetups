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

        public ActionResult Index()
        {
            var meetups = _context.Meetups
                .Include(m => m.Developer)
                .Include(m => m.Category)
                .Where(m => m.DateTime > DateTime.Now);

            var viewModel = new HomeViewModel
            {
                UpcomingMeetups = meetups,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
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