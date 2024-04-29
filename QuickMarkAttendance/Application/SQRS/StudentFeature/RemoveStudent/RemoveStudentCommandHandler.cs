using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Application.SQRS.Student.RemoveStudent;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.RemoveStudent
{
    public class RemoveStudentCommandHandler : ICommandHandler<RemoveStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existStudent = await _unitOfWork.StudentRepository.GetById(StudentId.Create(request.studentId));

                if (existStudent == null) return Result.Error("This student Is not exist");

                await _unitOfWork.StudentRepository.Delete(existStudent);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no changes");

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
