using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Domain.Entity.AttendanceDomain
{
    public class Attendance : Entity<AttendanceId>
    {
        public Attendance(AttendanceId id, CourseId courseId, StudentId studentId) : base(id)
        {
            CourseId = courseId;
            StudentId = studentId;


        }

        public CourseId CourseId { get; private set; }
        public Course Course { get; private set; }
        public StudentId StudentId { get; private set; }
        public Student Student { get; private set; }
        public DateTime DateTime { get; private init; } = DateTime.UtcNow;
 

        public static Attendance Create(CourseId courseId, StudentId studentId) 
        {
            return new(AttendanceId.CreateUnique(),courseId,studentId);
        }


    }
}
