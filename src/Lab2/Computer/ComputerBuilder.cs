using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Components.HDD;
using Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.Components.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Components.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Components.SystemUnitCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class ComputerBuilder : IComputerBuilder
{
    private readonly List<VideoCard> _videoCards = new();
    private readonly List<SSD> _ssds = new();
    private readonly List<HDD> _hdds = new();
    private MotherBoard? _motherBoard;
    private Processor? _processor;
    private BIOS? _bios;
    private CoolingSystem? _coolingSystem;
    private RAM? _ram;
    private SystemUnitCase? _unitCase;
    private PowerUnit? _powerUnit;
    private WiFiAdapter? _wiFiAdapter;

    public IComputerBuilder WithMotherBoard(MotherBoard? motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder WithProcessor(Processor? processor)
    {
        _processor = processor;
        return this;
    }

    public IComputerBuilder WithBIOS(BIOS? bios)
    {
        _bios = bios;
        return this;
    }

    public IComputerBuilder WithCoolingSystem(CoolingSystem? coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IComputerBuilder WithRAM(RAM? ram)
    {
        _ram = ram ?? throw new ArgumentNullException(nameof(ram));
        return this;
    }

    public IComputerBuilder AddVideoCard(VideoCard? videoCard)
    {
        if (videoCard == null) throw new ArgumentNullException(nameof(videoCard));
        _videoCards.Add(videoCard);
        return this;
    }

    public IComputerBuilder AddSSD(SSD ssd)
    {
        _ssds.Add(ssd);
        return this;
    }

    public IComputerBuilder AddHDD(HDD hdd)
    {
        _hdds.Add(hdd);
        return this;
    }

    public IComputerBuilder WithCase(SystemUnitCase? unitCase)
    {
        _unitCase = unitCase;
        return this;
    }

    public IComputerBuilder WithPowerUnit(PowerUnit? powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            _motherBoard ?? throw new ArgumentNullException(nameof(_motherBoard)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _bios,
            _coolingSystem ?? throw new ArgumentNullException(nameof(_coolingSystem)),
            _ram ?? throw new ArgumentNullException(nameof(_ram)),
            _videoCards,
            _ssds,
            _hdds,
            _unitCase ?? throw new ArgumentNullException(nameof(_unitCase)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _wiFiAdapter ?? throw new ArgumentNullException(nameof(_wiFiAdapter)));
    }
}