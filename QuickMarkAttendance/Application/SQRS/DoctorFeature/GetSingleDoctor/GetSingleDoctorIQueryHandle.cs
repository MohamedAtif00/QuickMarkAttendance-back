using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.GetSingleDoctor
{
    public class GetSingleDoctorIQueryHandle : IQueryHandler<GetSingleDoctorQuery, Doctor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleDoctorIQueryHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Doctor>> Handle(GetSingleDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.id));

                if (doctor == null) return Result.Error("this doctor is not exist");

                return Result.Success(doctor);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
