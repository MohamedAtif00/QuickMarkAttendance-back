using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class AttendanceRepository : GenericRepository<Attendance, AttendanceId>,IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Attendance>> GetAttendedStudentsForCourse(CourseId id)
        {
            return await _context.attendances.Where(x =>x.CourseId == id).ToListAsync();
        }
    }
}
