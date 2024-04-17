using Itmo.ObjectOrientedProgramming.Lab4.App;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors.Traversal;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Handlers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemTests
{
    [Fact]
    public void FirstTestCase()
    {
        // Arrange
        IParser parser = new Parser().SetDefaultParser()
            .AddNewHandler(new FileShowHandler(new ConcoleOutputer(new TextFormatter())));
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var app = new LocalFileSystemApp(
            parser,
            new ConcoleOutputer(new TextFormatter()),
            new OutputTraversal());
        app.Connect(fileSystem);

        string command = "file delete path";

        // Act
        app.Parse(command);

        // Assert
        app.FileSystem.Received()?.DeleteComponent("path");
    }

    [Fact]
    public void SecondTestCase()
    {
        // Arrange
        IParser parser = new Parser().SetDefaultParser()
            .AddNewHandler(new FileShowHandler(new ConcoleOutputer(new TextFormatter())));
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var app = new LocalFileSystemApp(
            parser,
            new ConcoleOutputer(new TextFormatter()),
            new OutputTraversal());
        app.Connect(fileSystem);

        string command = "file move path1 path2";

        // Act
        app.Parse(command);

        // Assert
        app.FileSystem.Received()?.MoveComponent("path1", "path2");
    }

    [Fact]
    public void ThirdTestCase()
    {
        // Arrange
        IParser parser = new Parser().SetDefaultParser()
            .AddNewHandler(new FileShowHandler(new ConcoleOutputer(new TextFormatter())));
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var app = new LocalFileSystemApp(
            parser,
            new ConcoleOutputer(new TextFormatter()),
            new OutputTraversal());
        app.Connect(fileSystem);

        string command = "file copy path1 path2";

        // Act
        app.Parse(command);

        // Assert
        app.FileSystem.Received()?.CopyComponent("path1", "path2");
    }

    [Fact]
    public void FourthTestCase()
    {
        // Arrange
        IParser parser = new Parser().SetDefaultParser()
            .AddNewHandler(new FileShowHandler(new ConcoleOutputer(new TextFormatter())));
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var app = new LocalFileSystemApp(
            parser,
            new ConcoleOutputer(new TextFormatter()),
            new OutputTraversal());
        app.Connect(fileSystem);

        string command = "file rename path name";

        // Act
        app.Parse(command);

        // Assert
        app.FileSystem.Received()?.RenameComponent("path", "name");
    }

    [Fact]
    public void FifthTestCase()
    {
        // Arrange
        IParser parser = new Parser().SetDefaultParser()
            .AddNewHandler(new FileShowHandler(new ConcoleOutputer(new TextFormatter())));
        IFileSystem fileSystem = Substitute.For<IFileSystem>();
        var app = new LocalFileSystemApp(
            parser,
            new ConcoleOutputer(new TextFormatter()),
            new OutputTraversal());
        app.Connect(fileSystem);

        string command = "tree goto tree";

        // Act
        app.Parse(command);

        // Assert
        app.FileSystem.Received()?.Checkout("tree");
    }
}