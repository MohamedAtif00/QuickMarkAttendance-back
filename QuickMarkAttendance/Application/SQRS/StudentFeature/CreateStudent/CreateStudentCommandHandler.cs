using Ardalis.Result;
using MediatR;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;
namespace QuickMarkAttendance.Application.SQRS.Student.CreateStudent
{
    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newStudent = student.Create(StudentId.Create(request.StudentId),request.Name);


                await _unitOfWork.StudentRepository.Add(newStudent);
                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("nothing changed");


                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
