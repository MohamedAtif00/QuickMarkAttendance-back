using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IStudentCourseRepository : IGenericRepository<StudentCourse,StudentCourseId>
    {
    }
}
