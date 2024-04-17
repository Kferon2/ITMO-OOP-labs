using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class FileShowHandler : IHandler
{
    public FileShowHandler(IOutputer outputer)
    {
        Outputer = outputer;
    }

    public IHandler? NextHandler { get; private set; }

    public IOutputer Outputer { get; }

    public void SetNext(IHandler handler)
    {
        NextHandler = handler;
    }

    public ICommand Handle(IList<string> request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request is ["file", "show", _, "-m", "console"]) return new FileShowCommand(request[2], Outputer);
        if (NextHandler == null) throw new ParseException("Invalid command");
        return NextHandler.Handle(request);
    }
}