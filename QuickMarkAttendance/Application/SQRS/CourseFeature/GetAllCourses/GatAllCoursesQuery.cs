using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetAllCourses
{
    public record GatAllCoursesQuery():IQuery<List<Course>>;
    
    
}
