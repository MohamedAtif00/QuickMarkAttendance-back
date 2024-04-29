using Ardalis.Result;
using MediatR;

namespace QuickMarkAttendance.Application.Abstraction
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, Result<TResult>>
       where TQuery : IQuery<TResult>
       where TResult : notnull
    {
    }
}
