using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Domain.Entity.QrCodeDomain
{
    public class QrCode : Entity<QrCodeId>
    {
        public QrCode(QrCodeId id) : base(id)
        {
        }
        public string Code { get; private set; }
        public CourseId CourseId { get; private set; }
        public Course Course { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public bool IsActive { get; private set; }
    }
}
