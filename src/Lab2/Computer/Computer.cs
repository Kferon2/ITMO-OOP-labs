using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class Computer
{
    public Computer(
        Components.MotherBoard.MotherBoard motherBoard,
        Components.Processor.Processor processor,
        Components.BIOS.BIOS? bios,
        Components.CoolingSystem.CoolingSystem coolingSystem,
        Components.RAM.RAM ram,
        IReadOnlyCollection<Components.VideoCard.VideoCard> videoCards,
        IReadOnlyCollection<Components.SSD.SSD> ssds,
        IReadOnlyCollection<Components.HDD.HDD> hdds,
        Components.SystemUnitCase.SystemUnitCase @case,
        Components.PowerUnit.PowerUnit powerUnit,
        Components.WiFiAdapter.WiFiAdapter? wiFiAdapter)
    {
        MotherBoard = motherBoard;
        Processor = processor;
        Bios = bios;
        CoolingSystem = coolingSystem;
        Ram = ram;
        VideoCards = videoCards;
        Ssds = ssds;
        Hdds = hdds;
        Case = @case;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
    }

    public Components.MotherBoard.MotherBoard MotherBoard { get; }

    public Components.Processor.Processor Processor { get; }

    public Components.BIOS.BIOS? Bios { get; }

    public Components.CoolingSystem.CoolingSystem CoolingSystem { get; }

    public Components.RAM.RAM Ram { get; }

    public IReadOnlyCollection<Components.VideoCard.VideoCard> VideoCards { get; }

    public IReadOnlyCollection<Components.SSD.SSD> Ssds { get; }

    public IReadOnlyCollection<Components.HDD.HDD> Hdds { get; }

    public Components.SystemUnitCase.SystemUnitCase Case { get; }

    public Components.PowerUnit.PowerUnit PowerUnit { get; }

    public Components.WiFiAdapter.WiFiAdapter? WiFiAdapter { get; }
}