using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public interface ICommand
{
    void Execute(IFileSystem fileSystem);
}