using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;
using QuickMarkAttendance.Domain.Entity.QrCodeDomain;
using QuickMarkAttendance.Domain.Entity.StudentCourseDomain;

namespace QuickMarkAttendance.Domain.Entity.CourseDomain
{
    public class Course : Entity<CourseId>
    {
        public Course(CourseId id, string name, DoctorId doctorId, string description, string Link) : base(id)
        {
            Name = name;
            DoctorId = doctorId;
            Description = description;
            this.Link = Link;
        }


        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public DoctorId DoctorId { get; private set; }
        public Doctor Doctor { get; private set; }
        public ICollection<QrCode> QrCodes { get; private set; }
        public ICollection<Attendance> Attendances { get; private set; }
        public ICollection<StudentCourse> StudentCourses { get; private set; }

        public static Course Create(string name, DoctorId doctorId,string description,string Link)
        {
            return new(CourseId.CreateUnique(),name,doctorId,description, Link);
        }

        public void Update(string name, DoctorId doctorId)
        {
            this.Name = name;
            this.DoctorId = doctorId;
        }
    }
}
