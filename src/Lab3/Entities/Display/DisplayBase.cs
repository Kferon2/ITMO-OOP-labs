using System;
using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayBase : IDisplay
{
    public DisplayBase(ConsoleColor textColor)
    {
        TextColor = textColor;
    }

    public DisplayBase()
    {
        TextColor = ConsoleColor.White;
    }

    public ConsoleColor TextColor { get; }

    public void ShowText(string text)
    {
        new Logger().Log(text, TextColor);
    }

    public void SaveText(string path, string text)
    {
        try
        {
            var streamWriter = new StreamWriter(path, true, Encoding.ASCII);
            streamWriter.WriteLine(text);
            streamWriter.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            throw;
        }
    }
}