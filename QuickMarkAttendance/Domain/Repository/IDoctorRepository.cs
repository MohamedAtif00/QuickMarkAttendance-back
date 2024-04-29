using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IDoctorRepository : IGenericRepository<Doctor,DoctorId>
    {
    }
}
