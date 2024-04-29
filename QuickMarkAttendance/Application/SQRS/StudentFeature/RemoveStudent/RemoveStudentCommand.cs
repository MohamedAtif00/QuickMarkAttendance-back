using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.Student.RemoveStudent
{
    public record RemoveStudentCommand(Guid studentId):ICommand;
    
    
}
