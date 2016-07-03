using AutoMapper;
using DevMeetups.Dtos;
using DevMeetups.Models;

namespace DevMeetups.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Meetup, MeetupDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}
