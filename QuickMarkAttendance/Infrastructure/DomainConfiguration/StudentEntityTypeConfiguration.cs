using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => StudentId.Create(x));
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
