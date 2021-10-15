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

        //add custom field configuration via IEntityTypeConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
