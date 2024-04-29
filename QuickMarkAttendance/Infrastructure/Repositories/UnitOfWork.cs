using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Repository;
using QuickMarkAttendance.Infrastructure.Data;

namespace QuickMarkAttendance.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext, IAttendanceRepository attendanceRepository, ICourseRepository courseRepository, IStudentRepository studentRepository, IStudentCourseRepository studentCourseRepository, IQrCodeRepository qrCodeRepository, IRefreshTokenRepository refreshTokenRepository, IDoctorRepository doctorRepository)
        {
            _applicationDbContext = applicationDbContext;
            AttendanceRepository = attendanceRepository;
            CourseRepository = courseRepository;
            StudentRepository = studentRepository;
            StudentCourseRepository = studentCourseRepository;
            QrCodeRepository = qrCodeRepository;
            RefreshTokenRepository = refreshTokenRepository;
            DoctorRepository = doctorRepository;
        }

        public IAttendanceRepository AttendanceRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IStudentCourseRepository StudentCourseRepository { get; }
        public IQrCodeRepository QrCodeRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }


        public async Task<int> save()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
