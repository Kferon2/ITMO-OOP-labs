using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;

public interface IOutputTraversal : IVisitor
{
    string? Result { get; }

    IOutputer Outputer { get; }

    ITextFormatter TextFormatter { get; }

    int Depth { get; }

    void SetDepth(int depth);

    void Write();
}