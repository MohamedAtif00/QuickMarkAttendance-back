using QuickMarkAttendance.Application.Abstraction;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.CheckIp
{
    public record CheckIpQuery(string ip) : IQuery<student>;
    
    
}
