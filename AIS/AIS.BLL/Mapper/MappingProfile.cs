using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>().ReverseMap()
                .ForMember(mem => mem.Company, cnf => cnf
                    .MapFrom(src => CreateMap<EmployeeEntity, CompanyEntity>()));

            CreateMap<IntervieweeEntity, Interviewee>().ReverseMap()
                .ForMember(mem => mem.Company, cnf => cnf
                    .MapFrom(src => CreateMap<IntervieweeEntity, CompanyEntity>()));

            CreateMap<CompanyEntity, Company>().ReverseMap();
        }
    }
}
