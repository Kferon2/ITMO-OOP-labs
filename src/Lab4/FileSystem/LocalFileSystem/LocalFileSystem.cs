using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem;

public class LocalFileSystem : IFileSystem
{
    private const int BasicDepth = 0;

    public LocalFileSystem(string root)
    {
        if (!Directory.Exists(root)) throw new DirectoryExistException("There is no directory for file system");
        Root = root;
        CurrentDirectory = new LocalWorkingDirectory(root);
    }

    public IList<IFileSystemComponent> Components { get; } = new List<IFileSystemComponent>();
    public string Root { get; private set; } = string.Empty;
    public IWorkingDirectory CurrentDirectory { get; private set; } = new LocalWorkingDirectory(string.Empty);

    public IOutputTraversal Traversal { get; } = new OutputTraversal();

    public void AcceptVisitor(IVisitor visitor, int depth = BasicDepth)
    {
        if (visitor == null) throw new ArgumentNullException(nameof(visitor));
        visitor.Visit(this, depth);
        Initialize();
        foreach (IFileSystemComponent component in Components) component.AcceptVisitor(visitor, depth + 1);
    }

    public void MoveComponent(string sourcePath, string destinationPath)
    {
        string begin = CheckPathType(sourcePath);
        string end = CheckPathType(destinationPath);
        if (File.Exists(begin)) File.Move(begin, end);
        else if (Directory.Exists(begin)) Directory.Move(begin, end);
        else throw new MoveException("Can't move file system component");
    }

    public void DeleteComponent(string path)
    {
        string begin = CheckPathType(path);
        if (File.Exists(begin)) File.Delete(path);
        else if (Directory.Exists(begin)) Directory.Delete(path);
        else throw new DeleteException("Can't delete file system component");
    }

    public void RenameComponent(string path, string name)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string begin = CheckPathType(path);
        if (File.Exists(begin))
            File.Move(path, $"{path[..(path.LastIndexOf("\\", StringComparison.Ordinal) - 1)]}\\{name}");
        else if (Directory.Exists(begin))
            Directory.Move(path, $"{path[..(path.LastIndexOf("\\", StringComparison.Ordinal) - 1)]}\\{name}");
        else throw new RenameException("Can't rename file system component");
    }

    public void CopyComponent(string sourcePath, string destinationPath)
    {
        string begin = CheckPathType(sourcePath);
        string end = CheckPathType(destinationPath);
        if (File.Exists(begin)) File.Copy(begin, end);
        else throw new CopyException("Can't copy file");
    }

    public void Disconnect()
    {
        Root = string.Empty;
        CurrentDirectory = new LocalWorkingDirectory(string.Empty);
        Components.Clear();
    }

    public void Initialize()
    {
        string[] files = Directory.GetFiles(CurrentDirectory.Path);
        string[] dirs = Directory.GetDirectories(CurrentDirectory.Path);

        Components.Clear();

        foreach (string file in files) Components.Add(new LocalFile(file));

        foreach (string dir in dirs) Components.Add(new LocalFolder(dir));
    }

    public string GetFileData(string path)
    {
        string begin = CheckPathType(path);
        var stringBuilder = new StringBuilder();
        if (!File.Exists(begin)) throw new FileExistException("This file doesn't exist");
        try
        {
            var sr = new StreamReader(begin);
            string? line = sr.ReadLine();
            while (line != null)
            {
                stringBuilder.Append(line).Append('\n');
                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(new StringBuilder().Append("Exception: ").Append(e.Message));
        }

        return stringBuilder.ToString();
    }

    public string GetDirectoryData(string path)
    {
        if (path == null) throw new ArgumentNullException(nameof(path));
        string begin = CheckPathType(path);
        var stringBuilder = new StringBuilder();
        if (!Directory.Exists(begin)) throw new DirectoryExistException("This directory doesn't exist");
        IDirectory directory = new LocalFolder(begin);
        directory.Initialize();
        foreach (IFileSystemComponent component in directory.Content)
        {
            if (File.Exists(component.Path)) stringBuilder.Append('\t').Append(component.Name).Append('\n');
            if (Directory.Exists(component.Path)) stringBuilder.Append('\t').Append(component.Name).Append('\n');
        }

        return stringBuilder.ToString();
    }

    public void Checkout(string path)
    {
        if (Directory.Exists(path)) CurrentDirectory = new LocalWorkingDirectory(path);
    }

    public void Connect(string path)
    {
        if (!Directory.Exists(path)) throw new DirectoryExistException("There is no directory for file system");
        Root = path;
        CurrentDirectory = new LocalWorkingDirectory(path);
        Components.Clear();
    }

    private string CheckPathType(string path)
    {
        string checkedPath = new StringBuilder().Append(CurrentDirectory.Path).Append('\\').Append(path).ToString();
        string checkedRoot = new StringBuilder().Append(Root).Append('\\').Append(path).ToString();
        if (File.Exists(checkedPath) || Directory.Exists(checkedPath))
            return checkedPath;
        if (File.Exists(checkedRoot) || Directory.Exists(checkedRoot))
            return checkedRoot;
        throw new ExistException("There is no path");
    }
}