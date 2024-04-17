using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class FuelStock : IObservable
{
    public FuelStockInfo FuelStockInfo { get; private set; } = new();

    private List<IObserver> Observers { get; set; } = new();

    public void RegisterObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver o in Observers)
        {
            o.Update(FuelStockInfo);
        }
    }

    public void Market()
    {
        var rnd = new Random();
        FuelStockInfo.ActivePlasma = rnd.Next(10, 20);
        FuelStockInfo.GravitonMatter = rnd.Next(15, 30);
        NotifyObservers();
    }
}