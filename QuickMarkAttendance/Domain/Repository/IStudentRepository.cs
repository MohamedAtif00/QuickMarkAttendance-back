
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Domain.Repository
{
    public interface IStudentRepository : IGenericRepository<Student, StudentId>
    {
        //Task<Student> GetStudentByIp(string ip);
    }


}
