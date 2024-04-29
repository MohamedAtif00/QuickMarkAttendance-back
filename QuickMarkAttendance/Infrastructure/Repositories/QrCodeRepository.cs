using QuickMarkAttendance.Domain.Entity.QrCodeDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class QrCodeRepository : GenericRepository<QrCode, QrCodeId>,IQrCodeRepository
    {
        public QrCodeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
