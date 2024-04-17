using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeListCommand : ICommand
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public void Execute(IFileSystem fileSystem)
    {
        if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
        fileSystem.Traversal.SetDepth(Depth);
        fileSystem.AcceptVisitor(fileSystem.Traversal, 0);
    }
}