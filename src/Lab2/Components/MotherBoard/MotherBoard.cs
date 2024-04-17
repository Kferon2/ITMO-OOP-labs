using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoard;

public class MotherBoard : IComponent
{
    public MotherBoard(
        string name,
        Sockets sockets,
        PciE pciE,
        Sata sata,
        MotherBoardChipSet chipSet,
        DDR ddr,
        int ramTablesCount,
        MotherBoardFormFactor formFactor,
        BIOS.BIOS bios)
    {
        new MotherBoardFormatValidator().Validate(
            name,
            sockets,
            pciE,
            sata,
            chipSet,
            ddr,
            ramTablesCount,
            formFactor,
            bios);
        Name = name;
        Sockets = sockets;
        PciE = pciE;
        Sata = sata;
        ChipSet = chipSet;
        Ddr = ddr;
        RAMTablesCount = ramTablesCount;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Name { get; }

    public Sockets Sockets { get; }

    public PciE PciE { get; }

    public Sata Sata { get; }

    public MotherBoardChipSet ChipSet { get; }

    public DDR Ddr { get; }

    public int RAMTablesCount { get; }

    public MotherBoardFormFactor FormFactor { get; }

    public BIOS.BIOS Bios { get; }
}