using DevMeetups.Models;
using DevMeetups.ViewModels;
using Microsoft.AspNet.Identity;
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

            return RedirectToAction("Index", "Home");
        }

    }
}
