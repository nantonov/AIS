using AIS.API.ViewModels;
using AIS.API.ViewModels.Employee;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap()
                .ForMember(mem => mem.Company, cnf => cnf
                    .MapFrom(src => CreateMap<ShortCompanyViewModel, Company>()));

            CreateMap<Interviewee, IntervieweeViewModel>().ReverseMap()
                .ForMember(mem => mem.Company, cnf => cnf
                    .MapFrom(src => CreateMap<ShortCompanyViewModel, Company>()));

            CreateMap<Company, CompanyViewModel>().ReverseMap();

            CreateMap<Company, ShortCompanyViewModel>();
        }
    }
}
