using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.Student.UpdateStudent
{
    public record UpdateStudentCommand(Guid studentId,string name):ICommand;
    
    
}
