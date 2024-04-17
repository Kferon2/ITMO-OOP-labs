using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayDriver : IDisplay
{
    private DisplayBase _display = new();

    public string CurrentText { get; private set; } = string.Empty;

    public void SetColor(ConsoleColor color)
    {
        _display = new DisplayBase(color);
    }

    public void SetText(string text)
    {
        CurrentText = text;
    }

    public void ShowText(string text)
    {
        _display.ShowText(text);
    }

    public void ShowText()
    {
        _display.ShowText(CurrentText);
    }

    public void AddText(string text)
    {
        SetText(CurrentText + text);
    }

    public void SaveText(string path, string text)
    {
        _display.SaveText(path, text);
    }
}