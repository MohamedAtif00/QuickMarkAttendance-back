using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetCoursesForDoctor
{
    public record GetCoursesForDoctorQuery(Guid id):IQuery<List<Course>>;
    
    
}
