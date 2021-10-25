using AIS.API.ViewModels;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class SessionViewModelProfile : Profile
    {
        public SessionViewModelProfile()
        {
            CreateMap<SessionViewModel, Session>().ReverseMap();
            CreateMap<SessionAddViewModel, Session>().ReverseMap();
            CreateMap<SessionUpdateViewModel, Session>().ReverseMap();
        }
    }
}