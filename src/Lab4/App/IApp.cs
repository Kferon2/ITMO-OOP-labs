using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.App;

public interface IApp
{
    IFileSystem? FileSystem { get; }

    IOutputer Outputer { get; }

    IOutputTraversal Traversal { get; }

    void Parse(string command);
}