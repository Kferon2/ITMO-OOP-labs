using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public class ProcessorBuilder : IProcessorBuilder
{
    private readonly List<int> _supportedMemoryFrequency = new();
    private string? _name;
    private int? _coreFrequency;
    private int? _coreCount;
    private Sockets? _sockets;
    private bool _builtInVideoCore;
    private int? _tdp;
    private int? _powerConsumption;

    public IProcessorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IProcessorBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;
        return this;
    }

    public IProcessorBuilder WithSockets(Sockets sockets)
    {
        _sockets = sockets;
        return this;
    }

    public IProcessorBuilder WithBuiltInVideoCore(bool builtInVideoCore)
    {
        _builtInVideoCore = builtInVideoCore;
        return this;
    }

    public IProcessorBuilder AddSupportedMemoryFrequency(int supportedMemoryFrequency)
    {
        _supportedMemoryFrequency.Add(supportedMemoryFrequency);
        return this;
    }

    public IProcessorBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IProcessorBuilder Direct(Processor component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithCoreFrequency(component.CoreFrequency)
            .WithCoreCount(component.CoreCount)
            .WithSockets(component.Sockets)
            .WithBuiltInVideoCore(component.BuiltInVideoCore)
            .WithTdp(component.TDP)
            .WithPowerConsumption(component.PowerConsumption);
        foreach (int frequency in component.SupportedMemoryFrequency)
            AddSupportedMemoryFrequency(frequency);

        return this;
    }

    public Processor Build()
    {
        return new Components.Processor.Processor(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _coreCount ?? throw new ArgumentNullException(nameof(_coreCount)),
            _sockets ?? throw new ArgumentNullException(nameof(_sockets)),
            _builtInVideoCore,
            _supportedMemoryFrequency ?? throw new ArgumentNullException(nameof(_supportedMemoryFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}