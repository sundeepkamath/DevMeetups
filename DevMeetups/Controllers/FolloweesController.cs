using DevMeetups.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace DevMeetups.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var followees = _context.Followings
                                .Where(f => f.FollowerId == userId)
                                .Select(f => f.Followee)
                                .ToList<ApplicationUser>();

            return View(followees);
        } 
    }
}
