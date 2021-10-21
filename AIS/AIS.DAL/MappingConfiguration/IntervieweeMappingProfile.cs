using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    public class IntervieweeMappingProfile : IEntityTypeConfiguration<IntervieweeEntity>
    {
        public void Configure(EntityTypeBuilder<IntervieweeEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasColumnName("Name");
            builder.Property(a => a.AppliesFor).HasColumnName("AppliesFor");
        }
    }
}
