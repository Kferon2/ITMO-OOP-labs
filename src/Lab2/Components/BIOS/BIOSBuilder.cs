using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;

public class BIOSBuilder : IBIOSBuilder
{
    private readonly List<string> _supportedProcessors = new();
    private string? _name;
    private string? _type;
    private string? _version;

    public IBIOSBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBIOSBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBIOSBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBIOSBuilder AddSupportedProcessor(string processor)
    {
        _supportedProcessors.Add(processor);
        return this;
    }

    public IBIOSBuilder Direct(BIOS component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithType(component.Type)
            .WithVersion(component.Version);
        foreach (string vaSupportedProcessor in component.SupportedProcessors)
            AddSupportedProcessor(vaSupportedProcessor);

        return this;
    }

    public BIOS Build()
    {
        return new Components.BIOS.BIOS(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportedProcessors);
    }
}