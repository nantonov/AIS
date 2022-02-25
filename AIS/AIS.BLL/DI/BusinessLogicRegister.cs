using AIS.BLL.Interfaces.Services;
using AIS.BLL.Models;
using AIS.BLL.Services;
using AIS.DAL.DI;
using AIS.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIS.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericService<Employee>), typeof(GenericService<Employee, EmployeeEntity>));
            services.AddScoped(typeof(IGenericService<Company>), typeof(GenericService<Company, CompanyEntity>));
            services.AddScoped<IGenericService<Interviewee>, IntervieweeService>();
            services.AddScoped<ISessionService, SessionService>(); services.AddScoped(typeof(IGenericService<QuestionArea>), typeof(GenericService<QuestionArea, QuestionAreaEntity>));
            services.AddScoped(typeof(IGenericService<QuestionSet>), typeof(GenericService<QuestionSet, QuestionSetEntity>));
            services.AddScoped(typeof(IGenericService<Question>), typeof(GenericService<Question, QuestionEntity>));
            services.AddScoped(typeof(IGenericService<TrueAnswer>), typeof(GenericService<TrueAnswer, TrueAnswerEntity>));
            services.AddScoped<INextQuestionService, NextQuestionService>();
            services.AddScoped(typeof(IGenericService<QuestionIntervieweeAnswer>), typeof(GenericService<QuestionIntervieweeAnswer, QuestionIntervieweeAnswerEntity>));
            services.AddDataAccess(config);
        }
    }
}