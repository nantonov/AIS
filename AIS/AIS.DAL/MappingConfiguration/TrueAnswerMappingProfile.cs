using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    public class TrueAnswerMappingProfile : IEntityTypeConfiguration<TrueAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<TrueAnswerEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
