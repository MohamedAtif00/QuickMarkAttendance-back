using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.StudentDomain;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.AddDegree
{
    public class AddDegreeCommandHandler : ICommandHandler<AddDegreeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDegreeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddDegreeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existStudent = await _unitOfWork.StudentRepository.GetById(StudentId.Create(request.StudentId));

                if (existStudent == null) return Result.Error("this student is not exist");

                existStudent.AddDegree(request.degree);

                await _unitOfWork.StudentRepository.Update(existStudent);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No change");

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
