using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.QrCodeDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IQrCodeRepository : IGenericRepository<QrCode,QrCodeId>
    {
    }
}
