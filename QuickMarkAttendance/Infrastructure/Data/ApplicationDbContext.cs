using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;
using QuickMarkAttendance.Domain.Entity.QrCodeDomain;
using QuickMarkAttendance.Domain.Entity.RefreshTokenDomain;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Attendance> attendances { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<QrCode> qrCodes { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
