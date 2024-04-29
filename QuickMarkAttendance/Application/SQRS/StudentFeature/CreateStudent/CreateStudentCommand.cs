using Ardalis.Result;
using MediatR;
using QuickMarkAttendance.Application.Abstraction;

namespace QuickMarkAttendance.Application.SQRS.Student.CreateStudent
{
    public record CreateStudentCommand(string Name, Guid StudentId) : ICommand;


}
