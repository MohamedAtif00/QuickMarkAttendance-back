using Ardalis.Result;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using student = QuickMarkAttendance.Domain.Entity.StudentDomain.Student;

namespace QuickMarkAttendance.Application.SQRS.StudentFeature.CheckIp
{
    public class CheckIpQueryHandler : IQueryHandler<CheckIpQuery, student>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckIpQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<student>> Handle(CheckIpQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var result = await _unitOfWork.StudentRepository.GetStudentByIp(request.ip);

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
