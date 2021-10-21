using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Interviewee;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Interviewee, IntervieweeViewModel>().ReverseMap();
            CreateMap<ChangeIntervieweeViewModel, Interviewee>();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<ChangeCompanyViewModel, Company>();
        }
    }
}
