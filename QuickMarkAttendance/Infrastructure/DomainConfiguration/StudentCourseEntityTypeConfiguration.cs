using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class StudentCourseEntityTypeConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>StudentCourseId.Create(x));
            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId);
            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId);
        }
    }
}
