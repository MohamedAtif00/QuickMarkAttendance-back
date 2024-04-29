using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.GetSingleDoctor
{
    public record GetSingleDoctorQuery(Guid id):IQuery<Doctor>;
    
    
}
