using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileCopyHandler : IHandler
{
    public IHandler? NextHandler { get; private set; }

    public void SetNext(IHandler handler)
    {
        NextHandler = handler;
    }

    public ICommand Handle(IList<string> request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request is ["file", "copy", _, _]) return new FileCopyCommand(request[2], request[3]);
        if (NextHandler == null) throw new ParseException("Invalid command");
        return NextHandler.Handle(request);
    }
}