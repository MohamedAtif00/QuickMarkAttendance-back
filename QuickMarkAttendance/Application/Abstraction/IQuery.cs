using Ardalis.Result;
using MediatR;

namespace QuickMarkAttendance.Application.Abstraction
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
    }
}
