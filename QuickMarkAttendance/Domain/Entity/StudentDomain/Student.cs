using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;

namespace QuickMarkAttendance.Domain.Entity.StudentDomain
{
    public class Student : Entity<StudentId>
    {
        private Student(StudentId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int degree { get; private set; } = 0;
        public ICollection<Attendance> Attendances { get; private set; }
        public ICollection<StudentCourse> StudentCourses { get; private set; }

        public static Student Create(string name)
        {
            return new(StudentId.CreateUnique(),name);
        }

        public static Student Create(StudentId id,string name)
        {
            return new(id, name);
        }

        public void Update(string name)
        {
            this.Name = name;
        }

        public void AddDegree(int degree)
        { 
            this.degree = degree;
        }
    }
}
