using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystemComponent
{
    string Name { get; }

    string Path { get; }

    void AcceptVisitor(IVisitor visitor, int depth);

    void Rename(string name);

    void Delete();
}