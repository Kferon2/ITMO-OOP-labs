using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAM;

public class RAMBuilder : IRAMBuilder
{
    private readonly List<JDEC> _jdecs = new();
    private readonly List<XMPProfile.XMPProfile> _xmpProfiles = new();
    private DDR? _ddr = new DDR(string.Empty);
    private string? _name;
    private int? _memoryCapacity;
    private MotherBoardFormFactor? _formFactor;
    private int? _powerConsumption;

    public IRAMBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRAMBuilder WithMemoryCapacity(int memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
        return this;
    }

    public IRAMBuilder WithFormFactor(MotherBoardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRAMBuilder WithDDR(DDR ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IRAMBuilder AddJDEC(JDEC jdec)
    {
        _jdecs.Add(jdec);
        return this;
    }

    public IRAMBuilder AddXMP(XMPProfile.XMPProfile xmpProfile)
    {
        _xmpProfiles.Add(xmpProfile);
        return this;
    }

    public IRAMBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRAMBuilder Direct(RAM component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithFormFactor(component.FormFactor)
            .WithMemoryCapacity(component.MemoryCapacity)
            .WithPowerConsumption(component.PowerConsumption);

        foreach (JDEC jdec in component.SupportedJdecs) AddJDEC(jdec);

        foreach (XMPProfile.XMPProfile profile in component.XmpProfiles) AddXMP(profile);

        return this;
    }

    public RAM Build()
    {
        return new Components.RAM.RAM(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _memoryCapacity ?? throw new ArgumentNullException(nameof(_memoryCapacity)),
            _jdecs,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _xmpProfiles,
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)));
    }
}