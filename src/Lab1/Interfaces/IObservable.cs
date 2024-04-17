namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IObservable
{
    void RegisterObserver(IObserver observer);

    void RemoveObserver(IObserver observer);

    void NotifyObservers();
}