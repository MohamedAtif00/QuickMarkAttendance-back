using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.CourseFeature.CreateCourse
{
    public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand,Course>
    {
        private  readonly IUnitOfWork   _unitOfWork;

        public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Course>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = Course.Create(request.Name,DoctorId.Create(request.DoctorId),request.description,request.link);

                var result = await _unitOfWork.CourseRepository.Add(course);


                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no changes");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
