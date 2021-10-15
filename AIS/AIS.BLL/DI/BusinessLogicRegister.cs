using AIS.BLL.Interfaces.Services;
using AIS.BLL.Services;
using AIS.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIS.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IIntervieweeService, IntervieweeService>();
            services.AddDataAccess(config);
        }
    }
}
