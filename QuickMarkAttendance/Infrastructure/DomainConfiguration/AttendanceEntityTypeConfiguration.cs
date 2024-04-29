using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;

namespace QuickMarkAttendance.Infrastructure.DomainConfiguration
{
    public class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, x => AttendanceId.Create(x));
            builder.Property(a => a.DateTime).IsRequired();
            builder.HasOne(a => a.Course)
                   .WithMany(c => c.Attendances)
                   .HasForeignKey(a => a.CourseId);
            builder.HasOne(a => a.Student)
                   .WithMany(s => s.Attendances)
                   .HasForeignKey(a => a.StudentId);
        }
    }
}
