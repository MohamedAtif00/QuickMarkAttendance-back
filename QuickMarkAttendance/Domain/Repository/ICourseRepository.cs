using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface ICourseRepository : IGenericRepository<Course, CourseId>
    {
        Task<List<Course>> GetCoursesForDoctor(DoctorId doctorId);
    }
}
