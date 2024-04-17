using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;

public class OutputTraversal : IOutputTraversal
{
    public OutputTraversal(IOutputer outputer, ITextFormatter textFormatter)
    {
        Outputer = outputer;
        TextFormatter = textFormatter;
    }

    public OutputTraversal()
    {
        Outputer = new ConcoleOutputer(new TextFormatter());
        TextFormatter = new TextFormatter();
    }

    public int Depth { get; private set; }

    public string Result => StringBuilder.ToString();

    public StringBuilder StringBuilder { get; } = new StringBuilder();
    public IOutputer Outputer { get; }
    public ITextFormatter TextFormatter { get; }

    public void SetDepth(int depth)
    {
        Depth = depth;
    }

    public void Visit(IFile file, int depth)
    {
        if (depth > Depth) return;
        if (file == null) throw new ArgumentNullException(nameof(file));
        string tabulation = string.Empty;
        for (int i = 0; i < depth; ++i) tabulation += "\t";
        StringBuilder.Append(tabulation).Append(TextFormatter.FileIcon).Append(file.Name).Append('\n');
    }

    public void Visit(IDirectory directory, int depth)
    {
        if (depth > Depth) return;
        if (directory == null) throw new ArgumentNullException(nameof(directory));
        string tabulation = string.Empty;
        for (int i = 0; i < depth; ++i) tabulation += "\t";
        StringBuilder.Append(tabulation).Append(TextFormatter.DirectoryIcon).Append(directory.Name).Append('\n');
    }

    public void Visit(IFileSystem system, int depth)
    {
        if (depth > Depth) return;
        if (system == null) throw new ArgumentNullException(nameof(system));
        Outputer.Write(system.Root);
    }

    public void Write()
    {
        Outputer.Write(Result);
    }
}