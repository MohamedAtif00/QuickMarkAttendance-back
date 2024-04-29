using MediatR;
using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.Attendance.AddAttendance
{
    public record CreateAttendanceCommand(Guid CourseId, Guid StudentId) : ICommand;


}
