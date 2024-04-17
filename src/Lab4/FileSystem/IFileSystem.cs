using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    IList<IFileSystemComponent> Components { get; }

    string Root { get; }

    IWorkingDirectory CurrentDirectory { get; }

    IOutputTraversal Traversal { get; }

    void AcceptVisitor(IVisitor visitor, int depth);

    void MoveComponent(string sourcePath, string destinationPath);

    void DeleteComponent(string path);

    void RenameComponent(string path, string name);

    void CopyComponent(string sourcePath, string destinationPath);

    void Checkout(string path);

    void Connect(string path);

    void Disconnect();

    void Initialize();

    string GetFileData(string path);

    string GetDirectoryData(string path);
}