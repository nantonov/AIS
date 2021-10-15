using AIS.API.ViewModels;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Interviewee, IntervieweeViewModel>().ReverseMap();
        }
    }
}
