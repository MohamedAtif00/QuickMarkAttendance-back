using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IAttendanceRepository : IGenericRepository<Attendance, AttendanceId>
    {
        Task<List<Attendance>> GetAttendedStudentsForCourse(CourseId id);
    }
}
