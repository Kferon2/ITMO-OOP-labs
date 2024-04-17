using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem;

public class LocalFolder : IDirectory
{
    public LocalFolder(string path)
    {
        Path = path ?? throw new ArgumentNullException(nameof(path));
        if (!Directory.Exists(Path)) throw new DirectoryExistException("This directory doesn't exist");
    }

    public string Name => Path[(Path.LastIndexOf("\\", StringComparison.Ordinal) + 1)..];
    public string Path { get; private set; }
    public IList<IFileSystemComponent> Content { get; } = new List<IFileSystemComponent>();

    public void Initialize()
    {
        string[] files = Directory.GetFiles(Path);
        string[] dirs = Directory.GetDirectories(Path);

        Content.Clear();

        foreach (string file in files) Content.Add(new LocalFile(file));

        foreach (string dir in dirs) Content.Add(new LocalFolder(dir));
    }

    public void AcceptVisitor(IVisitor visitor, int depth)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));
        visitor.Visit(this, depth);

        Initialize();

        foreach (IFileSystemComponent component in Content)
        {
            if (!File.Exists(component.Path))
            {
                if (!Directory.Exists(component.Path))
                    throw new ExistException("This directory or file doesn't exist");
            }

            component.AcceptVisitor(visitor, depth + 1);
        }
    }

    public void Rename(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        string destination = $"{Path[..(Path.LastIndexOf("\\", StringComparison.Ordinal) - 1)]}\\{name}";
        Directory.Move(Path, destination);
        Path = destination;
    }

    public void Delete()
    {
        Directory.Delete(Path);
    }
}