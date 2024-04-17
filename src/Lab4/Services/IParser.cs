using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IParser
{
    public IList<IHandler> Handlers { get; }

    public ICommand Parse(string command);

    IParser AddNewHandler(IHandler handler);
}