namespace QuickMarkAttendance.Application.DTOs.Course.Request
{
    public record CreateCourseRequest(string Name, Guid DoctorId, string description, string link);
    
    
}
