using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Domain.Entity.AttendanceDomain
{
    public class AttendanceId : ValueObjectId
    {
        protected AttendanceId(Guid id) : base(id)
        {
        }
        public static AttendanceId Create(Guid id)
        {
            return new(id);
        }

        public static AttendanceId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}