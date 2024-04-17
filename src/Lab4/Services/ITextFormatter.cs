namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface ITextFormatter
{
    string FileIcon { get; }

    string DirectoryIcon { get; }

    void SetFileIcon(string icon);

    void SetDirectoryIcon(string icon);
}