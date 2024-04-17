using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public interface IProcessorBuilder
{
    IProcessorBuilder WithName(string name);

    IProcessorBuilder WithCoreFrequency(int coreFrequency);

    IProcessorBuilder WithCoreCount(int coreCount);

    IProcessorBuilder WithSockets(Sockets sockets);

    IProcessorBuilder WithBuiltInVideoCore(bool builtInVideoCore);

    IProcessorBuilder AddSupportedMemoryFrequency(int supportedMemoryFrequency);

    IProcessorBuilder WithTdp(int tdp);

    IProcessorBuilder WithPowerConsumption(int powerConsumption);

    IProcessorBuilder Direct(Processor component);

    Processor Build();
}