using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IDirectory : IFileSystemComponent
{
    IList<IFileSystemComponent> Content { get; }

    void Initialize();
}