using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoard;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private string? _name;
    private Sockets? _sockets;
    private PciE? _pciE;
    private Sata? _sata;
    private MotherBoardChipSet? _chipSet;
    private DDR? _ddr;
    private int? _ramTablesCount;
    private MotherBoardFormFactor? _formFactor;
    private BIOS.BIOS? _bios;

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder WithSockets(Sockets sockets)
    {
        _sockets = sockets;
        return this;
    }

    public IMotherBoardBuilder WithPciE(PciE pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IMotherBoardBuilder WithSata(Sata sata)
    {
        _sata = sata;
        return this;
    }

    public IMotherBoardBuilder WithChipSet(MotherBoardChipSet chipSet)
    {
        _chipSet = chipSet;
        return this;
    }

    public IMotherBoardBuilder WithDDR(DDR ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IMotherBoardBuilder WithRamTablesCount(int ramTablesCount)
    {
        _ramTablesCount = ramTablesCount;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(MotherBoardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder WithBIOS(BIOS.BIOS? bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoardBuilder Direct(MotherBoard component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithFormFactor(component.FormFactor)
            .WithSata(component.Sata)
            .WithSockets(component.Sockets)
            .WithChipSet(component.ChipSet)
            .WithPciE(component.PciE)
            .WithDDR(component.Ddr)
            .WithRamTablesCount(component.RAMTablesCount)
            .WithBIOS(component.Bios);

        return this;
    }

    public MotherBoard Build()
    {
        return new Components.MotherBoard.MotherBoard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _sockets ?? throw new ArgumentNullException(nameof(_sockets)),
            _pciE ?? throw new ArgumentNullException(nameof(_pciE)),
            _sata ?? throw new ArgumentNullException(nameof(_sata)),
            _chipSet ?? throw new ArgumentNullException(nameof(_chipSet)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _ramTablesCount ?? throw new ArgumentNullException(nameof(_ramTablesCount)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)));
    }
}