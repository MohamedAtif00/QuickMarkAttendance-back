using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>CourseId.Create(x));
            builder.Property(x => x.DoctorId).HasConversion(x =>x.value,x =>DoctorId.Create(x));
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
