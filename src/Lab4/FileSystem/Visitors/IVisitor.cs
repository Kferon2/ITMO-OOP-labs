namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

public interface IVisitor
{
    void Visit(IFile file, int depth);

    void Visit(IDirectory directory, int depth);

    void Visit(IFileSystem system, int depth);
}