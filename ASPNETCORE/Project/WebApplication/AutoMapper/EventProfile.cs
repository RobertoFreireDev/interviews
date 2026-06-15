using AutoMapper;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.AutoMapper
{
    public class EventProfile  : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<EventViewModel, Event>();
        }        
    }
}
