using Microsoft.EntityFrameworkCore;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student, StudentId>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public async Task<Student> GetStudentByIp(string ip)
        //{
        //    return await _context.students.Where(x =>x.ip == ip).FirstOrDefaultAsync();
        //}
    }
}
