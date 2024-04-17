using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public class Processor : IComponent
{
    public Processor(
        string name,
        int coreFrequency,
        int coreCount,
        Sockets sockets,
        bool builtInVideoCore,
        IReadOnlyCollection<int> supportedMemoryFrequency,
        int tdp,
        int powerConsumption)
    {
        new ProcessorFormatValidator().Validate(
            name,
            coreFrequency,
            coreCount,
            sockets,
            supportedMemoryFrequency,
            tdp,
            powerConsumption);
        Name = name;
        CoreFrequency = coreFrequency;
        CoreCount = coreCount;
        Sockets = sockets;
        BuiltInVideoCore = builtInVideoCore;
        SupportedMemoryFrequency = supportedMemoryFrequency;
        TDP = tdp;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public int CoreFrequency { get; }

    public int CoreCount { get; }

    public Sockets Sockets { get; }

    public bool BuiltInVideoCore { get; }

    public IReadOnlyCollection<int> SupportedMemoryFrequency { get; }

    public int TDP { get; }

    public int PowerConsumption { get; }
}