using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.GetStudent
{
    public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, student>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStudentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<student>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.StudentRepository.GetById(StudentId.Create(request.studentId));

                if (result == null) return Result.Error("this student is not exist");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
