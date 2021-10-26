using AIS.API.ViewModels;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class SessionViewModelProfile : Profile
    {
        public SessionViewModelProfile()
        {
            CreateMap<Session, SessionViewModel>();
            CreateMap<Session, SessionAddViewModel>();
            CreateMap<Session, SessionUpdateViewModel >();
        }
    }
}