using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    public class QSMappingProfile : IEntityTypeConfiguration<QuestionSetEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionSetEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.HasMany(c => c.QuestionAreas)
            .WithMany(s => s.QuestionSets)
            .UsingEntity<QuestionAreasQuestionSetsEntity>();
        }
    }
}
