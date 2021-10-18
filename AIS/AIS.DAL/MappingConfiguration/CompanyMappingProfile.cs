using AIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIS.DAL.MappingConfiguration
{
    class CompanyMappingProfile : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name).HasColumnName("Name");

            builder.HasMany(company => company.Employees)
                .WithOne(employee => employee.Company)
                .HasForeignKey(employee => employee.CompanyId);
            builder.HasMany(company => company.Interviewees)
                .WithOne(employee => employee.Company)
                .HasForeignKey(employee => employee.CompanyId);
        }
    }
}
