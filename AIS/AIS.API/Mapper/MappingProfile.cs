using AIS.API.ViewModels;
using AIS.BLL.Models;
using AutoMapper;

namespace AIS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Interviewee, IntervieweeViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<QuestionArea, QuestionAreaViewModel>().ReverseMap();
            CreateMap<QuestionSet, QuestionSetViewModel>().ReverseMap();
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<TrueAnswer, TrueAnswerViewModel>().ReverseMap();
        }
    }
}
