using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public interface IComputerDirector
{
    Computer CreateComputer(StorageRepository storage, Config config, IComputerBuilder builder);
}