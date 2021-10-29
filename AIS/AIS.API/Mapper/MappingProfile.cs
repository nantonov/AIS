using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;
using AIS.API.ViewModels.Session;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<ChangeEmployeeViewModel, Employee>();
            CreateMap<Interviewee, IntervieweeViewModel>();
            CreateMap<ChangeIntervieweeViewModel, Interviewee>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<ChangeCompanyViewModel, Company>();
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionAddViewModel, Session>();
            CreateMap<SessionUpdateViewModel, Session>();
            CreateMap<Company, ShortCompanyViewModel>();
            CreateMap<Employee, ShortEmployeeViewModel>();
            CreateMap<Interviewee, ShortIntervieweeViewModel>();
        }
    }
}