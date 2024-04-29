using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.Student.UpdateStudent
{
    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existStudent = await _unitOfWork.StudentRepository.GetById(StudentId.Create(request.studentId));

                if (existStudent == null) return Result.Error("this student is not exist");

                existStudent.Update(request.name);

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
