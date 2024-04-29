using QuickMarkAttendance.Domain.Entity.DoctorDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor, DoctorId>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
