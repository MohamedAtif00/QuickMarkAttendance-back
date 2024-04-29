using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetCoursesForDoctor
{
    public class GetCoursesForDoctorQueryHandler : IQueryHandler<GetCoursesForDoctorQuery, List<Course>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCoursesForDoctorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Course>>> Handle(GetCoursesForDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetCoursesForDoctor(DoctorId.Create(request.id));

                if (result == null) return Result.Error("error");

                return Result.Success(result);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
