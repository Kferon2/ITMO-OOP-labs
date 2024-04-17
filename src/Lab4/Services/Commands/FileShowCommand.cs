using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShowCommand : ICommand
{
    public FileShowCommand(string path, IOutputer outputer)
    {
        Path = path;
        Outputer = outputer;
    }

    public string Path { get; }

    public IOutputer Outputer { get; }

    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        Outputer.Write(fileSystem.GetFileData(Path));
    }
}