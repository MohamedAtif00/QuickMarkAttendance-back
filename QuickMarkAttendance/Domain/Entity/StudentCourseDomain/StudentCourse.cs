using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Domain.Entity.StudentCourseDomain
{
    public class StudentCourse : Entity<StudentCourseId>
    {
        public StudentCourse(StudentCourseId id) : base(id)
        {
        }

        public StudentId StudentId { get; private set; }
        public Student Student { get; private set; }
        public CourseId CourseId { get; private set; }
        public Course Course { get; private set; }
    }
}
