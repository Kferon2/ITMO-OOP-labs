using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileCopyCommand : ICommand
{
    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }

    public string DestinationPath { get; }

    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        fileSystem.CopyComponent(SourcePath, DestinationPath);
    }
}