using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class Parser : IParser
{
    public IList<IHandler> Handlers { get; } = new List<IHandler>();

    public ICommand Parse(string command)
    {
        if (command == null) throw new ArgumentNullException(command);
        string[] parts = command.Split(' ');
        return Handlers[0].Handle(parts);
    }

    public IParser AddNewHandler(IHandler handler)
    {
        if (Handlers.Count > 0) Handlers[^1].SetNext(handler);
        Handlers.Add(handler);
        return this;
    }

    public IParser SetDefaultParser()
    {
        Handlers.Clear();
        return this.AddNewHandler(new ConnectHandler())
            .AddNewHandler(new DisconnectHandler())
            .AddNewHandler(new FileCopyHandler())
            .AddNewHandler(new FileDeleteHandler())
            .AddNewHandler(new FileMoveHandler())
            .AddNewHandler(new FileRenameHandler())
            .AddNewHandler(new TreeListHandler())
            .AddNewHandler(new TreeGoToHandler());
    }
}