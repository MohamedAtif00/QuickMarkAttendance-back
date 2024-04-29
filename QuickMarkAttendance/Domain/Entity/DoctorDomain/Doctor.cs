using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Domain.Entity.DoctorDomain
{
    public class Doctor : Entity<DoctorId>
    {
        public Doctor(DoctorId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public ICollection<Course> Courses { get; private set; }

        public static Doctor Create(string name)
        {
            return new(DoctorId.CreateUnique(),name);
        }

        public static Doctor Create(DoctorId id,string name)
        {
            return new(id, name);
        }



        public void Update(string name)
        {
            this.Name = name;
        }
    }
}
