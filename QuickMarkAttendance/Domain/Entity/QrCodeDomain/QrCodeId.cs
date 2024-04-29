using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;

namespace QuickMarkAttendance.Domain.Entity.QrCodeDomain
{
    public class QrCodeId : ValueObjectId
    {
        protected QrCodeId(Guid id) : base(id)
        {
        }

        public static QrCodeId Create(Guid id)
        {
            return new(id);
        }

        public static QrCodeId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}