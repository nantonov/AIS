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
        public DbSet<SessionEntity> Sessions { get; set; }
        public DbSet<QuestionAreaEntity> QuestionAreas { get; set; }
        public DbSet<QuestionSetEntity> QuestionSets { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<TrueAnswerEntity> TrueAnswers { get; set; }
        public DbSet<QuestionAreasQuestionSetsEntity> QuestionAreasQuestionSets { get; set; }
        public DbSet<QuestionsQuestionSetsEntity> QuestionsQuestionSets { get; set; }
        public DbSet<QuestionIntervieweeAnswerEntity> QuestionIntervieweeAnswers { get; set; }


        //add custom field configuration via IEntityTypeConfiguration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}