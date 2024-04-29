using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.GetAllDoctors
{
    public record GetAllDoctorsQuery():IQuery<List<Doctor>>;
    
    
}
