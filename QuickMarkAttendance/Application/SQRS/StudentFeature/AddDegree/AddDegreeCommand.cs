using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.AddDegree
{
    public record AddDegreeCommand(Guid StudentId,int degree):ICommand;
    
    
}
