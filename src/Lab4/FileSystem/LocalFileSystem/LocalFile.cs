using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem;

public class LocalFile : IFile
{
    public LocalFile(string path)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        if (!File.Exists(Path)) throw new FileExistException("This file doesn't exist");
    }

    public string Name => Path[(Path.LastIndexOf("\\", StringComparison.Ordinal) + 1)..];
    public string Path { get; private set; }

    public void AcceptVisitor(IVisitor visitor, int depth)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));
        visitor.Visit(this, depth);
    }

    public void Rename(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        string destination = $"{Path[..(Path.LastIndexOf("\\", StringComparison.Ordinal) - 1)]}\\{name}";
        File.Move(Path, destination);
        Path = destination;
    }

    public void Delete()
    {
        File.Delete(Path);
    }
}