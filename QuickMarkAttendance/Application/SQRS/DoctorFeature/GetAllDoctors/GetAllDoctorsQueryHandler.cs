using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.DoctorDomain;

namespace QuickMarkAttendance.Application.SQRS.DoctorFeature.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IQueryHandler<GetAllDoctorsQuery, List<Doctor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.DoctorRepository.GetAll();

                if (result == null) return Result.Error("Error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
