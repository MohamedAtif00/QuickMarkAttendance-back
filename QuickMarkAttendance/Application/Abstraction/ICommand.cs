using Ardalis.Result;
using MediatR;

namespace QuickMarkAttendance.Application.Abstraction
{
    public interface ICommand<T> : IRequest<Result<T>>
    {
    }

    public interface ICommand : IRequest<Result>
    { }
}
