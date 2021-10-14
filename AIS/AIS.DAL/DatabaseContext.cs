using Microsoft.EntityFrameworkCore;

namespace AIS.DAL
{
    class DatabaseContext : DbContext
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

        //add custom field configuration via IEntityTypeConfiguration
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(<mapping_config>).Assembly);
        }*/
    }
}
