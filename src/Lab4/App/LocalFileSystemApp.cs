using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.App;

public class LocalFileSystemApp : IApp
{
    public LocalFileSystemApp(IParser parser, IOutputer outputer, IOutputTraversal traversal)
    {
        Parser = parser;
        Outputer = outputer ?? throw new ArgumentNullException(nameof(outputer));
        Traversal = traversal ?? throw new ArgumentNullException(nameof(traversal));
    }

    public IParser Parser { get; }
    public IFileSystem? FileSystem { get; private set; }

    public IOutputer Outputer { get; }

    public IOutputTraversal Traversal { get; }

    public void Connect(string path)
    {
        FileSystem = new LocalFileSystem(path);
    }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        FileSystem = null;
    }

    public void ConcoleParse()
    {
        string? command = Console.ReadLine();
        if (command != null) Parse(command);
    }

    public void Parse(string command)
    {
        if (FileSystem == null) throw new ArgumentNullException(nameof(command));
        Parser.Parse(command).Execute(FileSystem);
    }
}