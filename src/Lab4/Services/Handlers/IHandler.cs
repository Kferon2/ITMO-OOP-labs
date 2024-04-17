using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;

public interface IHandler
{
    IHandler? NextHandler { get; }

    void SetNext(IHandler handler);

    ICommand Handle(IList<string> request);
}