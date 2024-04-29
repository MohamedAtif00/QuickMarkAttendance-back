using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.CreateCourse
{
    public record CreateCourseCommand(string Name, Guid DoctorId,string description,string link) :ICommand<Course>;
    
    
}
