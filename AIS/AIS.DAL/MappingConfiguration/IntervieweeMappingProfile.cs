using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    class IntervieweeMappingProfile : IEntityTypeConfiguration<IntervieweeEntity>
    {
        public void Configure(EntityTypeBuilder<IntervieweeEntity> builder)
        {
            builder.HasKey(a => a.IntervieweeId);
            builder.Property(a => a.IntervieweeId).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasColumnName("Name");
            builder.Property(a => a.AppliesFor).HasColumnName("AppliesFor");
        }
    }
}
