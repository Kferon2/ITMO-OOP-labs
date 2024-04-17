using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        fileSystem.Connect(Path);
    }
}