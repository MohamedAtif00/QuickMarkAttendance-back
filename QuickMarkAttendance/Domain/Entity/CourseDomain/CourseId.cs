using QuickMarkAttendance.Domain.Abstraction;

namespace QuickMarkAttendance.Domain.Entity.CourseDomain
{
    public class CourseId : ValueObjectId
    {
        protected CourseId(Guid id) : base(id)
        {
        }

        public static CourseId Create(Guid id)
        {
            return new(id);
        }

        public static CourseId CreateUnique()
        {
            return new(Guid.NewGuid()) ;
        }
    }
}