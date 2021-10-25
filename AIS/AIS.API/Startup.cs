using AIS.API.Mappers;
using System.Reflection;
using AIS.API.Mapper;
using AIS.API.MiddleWare;
using AIS.API.ViewModels.Employee;
using AIS.BLL.DI;
using AIS.BLL.Mappers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AIS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(API.Mapper.MappingProfile).Assembly, typeof(BLL.Mapper.MappingProfile).Assembly);

            services.AddAutoMapper(typeof(API.Mapper.SessionViewModelProfile), typeof(BLL.Mapper.SessionProfile));
            services.AddAutoMapper(typeof(API.Mapper.SessionViewModelProfile).Assembly, typeof(BLL.Mapper.SessionProfile).Assembly);

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("AIS.API")));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AIS.API", Version = "v1" });
            });
            services.AddBusinessLogic(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIS.API v1"));
            }
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}