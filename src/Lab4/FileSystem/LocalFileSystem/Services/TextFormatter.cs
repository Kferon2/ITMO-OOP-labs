using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem.Services;

public class TextFormatter : ITextFormatter
{
    public string FileIcon { get; private set; } = "\u1f4c4";
    public string DirectoryIcon { get; private set; } = "\u1f4c2";

    public void SetFileIcon(string icon)
    {
        FileIcon = icon;
    }

    public void SetDirectoryIcon(string icon)
    {
        DirectoryIcon = icon;
    }
}