using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using attendance = QuickMarkAttendance.Domain.Entity.AttendanceDomain.Attendance;

namespace QuickMarkAttendance.Application.SQRS.AttendanceFeature.GetAllAttendedStudentsForCourse
{
    public record GetAttendedStudentsForCourseQuery(Guid courseId):IQuery<List<attendance>>;
    
    
}
