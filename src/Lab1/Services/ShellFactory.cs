using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ShellFactory
{
    public ShellBasic FirstClassShell()
    {
        return new ShellBasic(100, 100);
    }

    public ShellBasic SecondClassShell()
    {
        return new ShellBasic(800, 800);
    }

    public ShellBasic ThirdClassShell()
    {
        return new ShellBasic(2000, 2000);
    }
}