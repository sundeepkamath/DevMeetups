using DevMeetups.Dtos;
using DevMeetups.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace DevMeetups.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            bool exists = _context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId);

            if (exists)
            {
                return BadRequest("Following already exists!");
            }


            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
