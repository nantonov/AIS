using AIS.API.ViewModels.Session;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class SessionViewModelProfile : Profile
    {
        public SessionViewModelProfile()
        {
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionAddViewModel, Session>();
            CreateMap<SessionUpdateViewModel, Session >();
        }
    }
}