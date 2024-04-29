using QuickMarkAttendance.Domain.Repository;

namespace QuickMarkAttendance.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        IAttendanceRepository AttendanceRepository { get; }
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
        IQrCodeRepository QrCodeRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IDoctorRepository DoctorRepository { get; }

        Task<int> save();
    }
}