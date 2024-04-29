using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.QrCodeDomain;

namespace QuickMarkAttendance.Domain.Entity.StudentCourseDomain
{
    public class StudentCourseId : ValueObjectId
    {
        protected StudentCourseId(Guid id) : base(id)
        {
        }

        public static StudentCourseId Create(Guid id)
        {
            return new(id);
        }

        public static StudentCourseId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}