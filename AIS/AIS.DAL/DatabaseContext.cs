using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIS.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
        }

        public DatabaseContext()
        {
            Database.Migrate();
        }

        public DbSet<IntervieweeEntity> Interviewees { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }

        //add custom field configuration via IEntityTypeConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            modelBuilder.Entity<EmployeeEntity>().Navigation(x => x.Company).AutoInclude();
            modelBuilder.Entity<IntervieweeEntity>().Navigation(x => x.Company).AutoInclude();
            modelBuilder.Entity<CompanyEntity>().Navigation(x => x.Interviewees).AutoInclude();
            modelBuilder.Entity<CompanyEntity>().Navigation(x => x.Employees).AutoInclude();
        }
    }
}
