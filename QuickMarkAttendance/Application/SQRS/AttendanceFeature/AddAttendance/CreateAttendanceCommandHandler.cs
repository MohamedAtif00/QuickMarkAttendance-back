using Ardalis.Result;
using MediatR;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Domain.Abstraction;
using QuickMarkAttendance.Domain.Entity.AttendanceDomain;
using QuickMarkAttendance.Domain.Entity.CourseDomain;
using QuickMarkAttendance.Domain.Entity.StudentDomain;
using attendance = QuickMarkAttendance.Domain.Entity.AttendanceDomain.Attendance;

namespace QuickMarkAttendance.Application.SQRS.Attendance.AddAttendance
{
    public class CreateAttendanceCommandHandler : ICommandHandler<CreateAttendanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAttendanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var newAttendance = attendance.Create(CourseId.Create(request.CourseId), StudentId.Create(request.StudentId));


                var result = await _unitOfWork.AttendanceRepository.Add(newAttendance);

                int saveing = await _unitOfWork.save();

                if (saveing == null) return Result.Error("no changes");

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }
    }
}
