using AIS.API.ViewModels;
using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;
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
            CreateMap<QuestionArea, QuestionAreaViewModel>().ReverseMap();
            CreateMap<QuestionSet, QuestionSetViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<TrueAnswer, TrueAnswerViewModel>().ReverseMap();
        }
    }
}
