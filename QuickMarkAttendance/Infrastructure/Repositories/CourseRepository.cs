using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course, CourseId>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Course>> GetCoursesForDoctor(DoctorId doctorId)
        {
            return await _context.courses.Where(x =>x.DoctorId == doctorId).ToListAsync();
        }
    }
}
