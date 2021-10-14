using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIS.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(op =>
                {
                    op.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                }
            );
        }
    }
}
