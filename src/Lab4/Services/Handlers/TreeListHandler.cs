using System;
using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public class TreeListHandler : IHandler
{
    public IHandler? NextHandler { get; private set; }

    public void SetNext(IHandler handler)
    {
        NextHandler = handler;
    }

    public ICommand Handle(IList<string> request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (request is ["tree", "list", "-d", _])
            return new TreeListCommand(int.Parse(request[3], new NumberFormatInfo()));
        if (NextHandler == null) throw new ParseException("Invalid command");
        return NextHandler.Handle(request);
    }
}