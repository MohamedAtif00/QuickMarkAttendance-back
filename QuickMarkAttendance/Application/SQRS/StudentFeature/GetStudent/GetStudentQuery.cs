using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.GetStudent
{
    public record GetStudentQuery(Guid studentId) : IQuery<student>;
    
    
}
