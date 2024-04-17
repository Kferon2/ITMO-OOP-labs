using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        fileSystem.RenameComponent(Path, Name);
    }
}