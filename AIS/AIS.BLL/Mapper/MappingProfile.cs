using AIS.BLL.Models;
using AIS.DAL.Entities;
using AutoMapper;

namespace AIS.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IntervieweeEntity, Interviewee>().ReverseMap();
            CreateMap<CompanyEntity, Company>().ReverseMap();
            CreateMap<QuestionAreaEntity, QuestionArea>().ReverseMap();
            CreateMap<QuestionSetEntity, QuestionSet>().ReverseMap();
            CreateMap<QuestionEntity, Question>().ReverseMap();
            CreateMap<TrueAnswerEntity, TrueAnswer>().ReverseMap();
            CreateMap<EmployeeEntity, Employee>().ReverseMap(); 
            CreateMap<SessionEntity, Session>().ReverseMap();
            CreateMap<QuestionIntervieweeAnswer, QuestionIntervieweeAnswerEntity>().ReverseMap();
        }
    }
}
