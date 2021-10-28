using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<IntervieweeEntity, Interviewee>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
        }
    }
}
