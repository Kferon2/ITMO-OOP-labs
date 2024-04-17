namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplay
{
    void ShowText(string text);

    void SaveText(string path, string text);
}