using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IQueryHandler<GatAllCoursesQuery, List<Course>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Course>>> Handle(GatAllCoursesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.CourseRepository.GetAll();

                if (result == null) return Result.Error("Error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
