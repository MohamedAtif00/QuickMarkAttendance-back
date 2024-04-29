using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetSingleCourse
{
    public record GetSingleCourseQuery(Guid id):IQuery<Course>;
    
    
}
