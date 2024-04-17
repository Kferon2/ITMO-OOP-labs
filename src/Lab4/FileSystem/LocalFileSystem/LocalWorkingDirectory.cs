using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem;

public class LocalWorkingDirectory : IWorkingDirectory
{
    public LocalWorkingDirectory(string path)
    {
        if (!Directory.Exists(path)) throw new DirectoryExistException("This directory doesn't exist");
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public string Path { get; private set; }

    public string Name => Path[(Path.LastIndexOf("\\", StringComparison.Ordinal) + 1)..];
}