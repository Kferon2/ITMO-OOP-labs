namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IOutputer
{
    ITextFormatter Formatter { get; }
    void Write(string data);
}