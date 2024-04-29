using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class StudentCourseRepository : GenericRepository<StudentCourse, StudentCourseId>, IStudentCourseRepository
    {
        public StudentCourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
