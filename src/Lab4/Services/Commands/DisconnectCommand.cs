using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        fileSystem.Disconnect();
    }
}