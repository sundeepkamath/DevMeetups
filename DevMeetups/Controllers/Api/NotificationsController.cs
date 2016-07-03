using AutoMapper;
using DevMeetups.Dtos;
using DevMeetups.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace DevMeetups.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        ApplicationDbContext _context = null;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotfications
                                    .Where(u => u.IsRead == false && u.UserId == userId)
                                    .Select(u => u.Notification)
                                    .Include(n => n.Meetup.Developer)
                                    .ToList<Notification>();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }
    }
}
