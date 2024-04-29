using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.GetSingleCourse
{
    public class GetSingleCourseQueryHandler : IQueryHandler<GetSingleCourseQuery, Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleCourseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Course>> Handle(GetSingleCourseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var course = await _unitOfWork.CourseRepository.GetById(CourseId.Create(request.id));

                if (course == null) return Result.Error("this course is not exist");

                return Result.Success(course);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
