using DevMeetups.Dtos;
using DevMeetups.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace DevMeetups.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            bool exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.MeetupId == dto.MeetupId);

            if (exists)
            {
                return BadRequest("The attendance already exists.");
            }

            var attendance = new Attendance
            {
                MeetupId = dto.MeetupId,
                AttendeeId = User.Identity.GetUserId()
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
 