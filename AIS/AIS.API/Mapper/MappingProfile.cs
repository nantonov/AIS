using AIS.API.ViewModels.Company;
using AIS.API.ViewModels.Employee;
using AIS.API.ViewModels.Interviewee;
using AIS.API.ViewModels.Question;
using AIS.API.ViewModels.QuestionArea;
using AIS.API.ViewModels.QuestionIntervieweeAnswer;
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
            CreateMap<ChangeCompanyViewModel, Company>();
            CreateMap<Company, ShortCompanyViewModel>();
            CreateMap<Company, CompanyViewModel>();

            CreateMap<ChangeEmployeeViewModel, Employee>();
            CreateMap<Employee, ShortEmployeeViewModel>();
            CreateMap<Employee, EmployeeViewModel>();

            CreateMap<Interviewee, IntervieweeViewModel>();
            CreateMap<Interviewee, ShortIntervieweeViewModel>();
            CreateMap<ChangeIntervieweeViewModel, Interviewee>();

            CreateMap<QuestionArea, QuestionAreaViewModel>();
            CreateMap<QuestionAreaAddViewModel, QuestionArea>();
            CreateMap<QuestionAreaUpdateViewModel, QuestionArea>();
            CreateMap<QuestionArea, ShortQuestionAreaViewModel>();

            CreateMap<QuestionSet, QuestionSetViewModel>();
            CreateMap<QuestionSetAddViewModel, QuestionSet>();
            CreateMap<QuestionSetUpdateViewModel, QuestionSet>();
            CreateMap<QuestionSet, ShortQuestionSetViewModel>();

            CreateMap<Question, QuestionViewModel>();
            CreateMap<QuestionAddViewModel, Question>();
            CreateMap<QuestionUpdateViewModel, Question>();
            CreateMap<Question, ShortQuestionViewModel>();

            CreateMap<TrueAnswer, TrueAnswerViewModel>();
            CreateMap<TrueAnswerAddViewModel, TrueAnswer>();
            CreateMap<TrueAnswerUpdateViewModel, TrueAnswer>();
            CreateMap<TrueAnswer, ShortTrueAnswerViewModel>();

            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionAddViewModel, Session>();
            CreateMap<SessionUpdateViewModel, Session>();
            CreateMap<Session, ShortSessionViewModel>();

            CreateMap<QuestionIntervieweeAnswer, QuestionIntervieweeAnswerViewModel>();
            CreateMap<QuestionIntervieweeAnswerUpdateViewModel, QuestionIntervieweeAnswer>();
            CreateMap<QuestionIntervieweeAnswerAddViewModel, QuestionIntervieweeAnswer>();
            CreateMap<QuestionIntervieweeAnswer, QuestionIntervieweeAnswerAddViewModel>();
            CreateMap<QuestionIntervieweeAnswer, ShortQuestionIntervieweeAnswerViewModel>();
        }
    }
}