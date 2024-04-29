using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;

namespace QuickMarkAttendance.Domain.Entity.StudentDomain
{
    public class StudentId : ValueObjectId
    {
        protected StudentId(Guid id) : base(id)
        {
        }

        public static StudentId Create(Guid id)
        {
            return new(id);
        }

        public static StudentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}