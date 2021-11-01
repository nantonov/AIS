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
            CreateMap<QuestionArea, QuestionAreaViewModel>();
            CreateMap<QuestionSet, QuestionSetViewModel>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<TrueAnswer, TrueAnswerViewModel>();
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionAddViewModel, Session>();
            CreateMap<SessionUpdateViewModel, Session>();
            CreateMap<Company, ShortCompanyViewModel>();
            CreateMap<Employee, ShortEmployeeViewModel>();
            CreateMap<Interviewee, ShortIntervieweeViewModel>();
            CreateMap<QuestionAreaAddViewModel, QuestionArea>();
            CreateMap<QuestionSetAddViewModel, QuestionSet>();
            CreateMap<QuestionAddViewModel, Question>();
            CreateMap<TrueAnswerAddViewModel, TrueAnswer>();
            CreateMap<QuestionAreaUpdateViewModel, QuestionArea>();
            CreateMap<QuestionSetUpdateViewModel, QuestionSet>();
            CreateMap<QuestionUpdateViewModel, Question>();
            CreateMap<TrueAnswerUpdateViewModel, TrueAnswer>();
        }
    }
}