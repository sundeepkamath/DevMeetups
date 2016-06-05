using DevMeetups.Models;
using DevMeetups.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new MeetupsFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

    }
}
