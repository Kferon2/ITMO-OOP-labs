using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoard;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithName(string name);

    IMotherBoardBuilder WithSockets(Sockets sockets);

    IMotherBoardBuilder WithPciE(PciE pciE);

    IMotherBoardBuilder WithSata(Sata sata);

    IMotherBoardBuilder WithChipSet(MotherBoardChipSet chipSet);

    IMotherBoardBuilder WithDDR(DDR ddr);

    IMotherBoardBuilder WithRamTablesCount(int ramTablesCount);

    IMotherBoardBuilder WithFormFactor(MotherBoardFormFactor formFactor);

    IMotherBoardBuilder WithBIOS(BIOS.BIOS? bios);

    IMotherBoardBuilder Direct(MotherBoard component);

    MotherBoard Build();
}