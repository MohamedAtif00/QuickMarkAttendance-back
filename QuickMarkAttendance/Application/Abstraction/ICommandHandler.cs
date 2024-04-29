﻿using Ardalis.Result;
using MediatR;

namespace QuickMarkAttendance.Application.Abstraction
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, Result<TResult>>
         where TCommand : ICommand<TResult>
         where TResult : notnull
    {
    }

    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }
}
