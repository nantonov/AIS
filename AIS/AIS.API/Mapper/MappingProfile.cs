using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;
using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.QuestionArea;
using AIS.API.ViewModels.QuestionSet;
using AIS.API.ViewModels.Session;
using AIS.API.ViewModels.TrueAnswer;
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
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionAddViewModel, Session>();
            CreateMap<SessionUpdateViewModel, Session>();
            CreateMap<Company, ShortCompanyViewModel>();
            CreateMap<Employee, ShortEmployeeViewModel>();
            CreateMap<Interviewee, ShortIntervieweeViewModel>();
            CreateMap<QuestionAreaAddViewModel, QuestionArea>().ReverseMap();
            CreateMap<QuestionSetAddViewModel, QuestionSet>().ReverseMap();
            CreateMap<QuestionAddViewModel, Question>().ReverseMap();
            CreateMap<TrueAnswerAddViewModel, TrueAnswer>().ReverseMap();
            CreateMap<QuestionAreaUpdateViewModel, QuestionArea>().ReverseMap();
            CreateMap<QuestionSetUpdateViewModel, QuestionSet>().ReverseMap();
            CreateMap<QuestionUpdateViewModel, Question>().ReverseMap();
            CreateMap<TrueAnswerUpdateViewModel, TrueAnswer>().ReverseMap();
        }
    }
}