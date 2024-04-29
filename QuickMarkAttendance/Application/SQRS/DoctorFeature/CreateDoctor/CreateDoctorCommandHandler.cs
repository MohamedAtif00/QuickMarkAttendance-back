using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.CreateDoctor
{
    public class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.DoctorRepository.Add(Doctor.Create(DoctorId.Create(request.doctorId),request.name));

                if (result == null) return Result.Error("Error");

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no changes");

                return Result.Success();
            }catch  (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
