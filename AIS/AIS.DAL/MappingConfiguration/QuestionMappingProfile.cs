using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    public class QuestionMappingProfile : IEntityTypeConfiguration<QuestionEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
