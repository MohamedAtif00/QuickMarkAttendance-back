using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using attendance = QuickMarkAttendance.Domain.Entity.AttendanceDomain.Attendance;

namespace QuickMarkAttendance.Application.SQRS.AttendanceFeature.GetAllAttendedStudentsForCourse
{
    public class GetAttendedStudentsForCourseQueryHandler : IQueryHandler<GetAttendedStudentsForCourseQuery, List<attendance>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAttendedStudentsForCourseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<attendance>>> Handle(GetAttendedStudentsForCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.AttendanceRepository.GetAttendedStudentsForCourse(CourseId.Create(request.courseId));

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
