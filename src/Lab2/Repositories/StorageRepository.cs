using System;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class StorageRepository
{
    public StorageRepository()
    {
    }

    public StorageRepository(
        ComponentRepository<CoolingSystem> coolingRepository,
        ComponentRepository<BIOS> biosRepository,
        ComponentRepository<HDD> hddRepository,
        ComponentRepository<MotherBoard> motherBoardRepository,
        ComponentRepository<PowerUnit> powerUnitRepository,
        ComponentRepository<Processor> processorRepository,
        ComponentRepository<RAM> ramRepository,
        ComponentRepository<SSD> ssdRepository,
        ComponentRepository<SystemUnitCase> systemUnitCaseRepository,
        ComponentRepository<VideoCard> videoCardRepository,
        ComponentRepository<WiFiAdapter> wiFiRepository)
    {
        CoolingRepository = coolingRepository ?? throw new ArgumentNullException(nameof(coolingRepository));
        BiosRepository = biosRepository ?? throw new ArgumentNullException(nameof(biosRepository));
        HddRepository = hddRepository ?? throw new ArgumentNullException(nameof(hddRepository));
        MotherBoardRepository = motherBoardRepository ?? throw new ArgumentNullException(nameof(motherBoardRepository));
        PowerUnitRepository = powerUnitRepository ?? throw new ArgumentNullException(nameof(powerUnitRepository));
        ProcessorRepository = processorRepository ?? throw new ArgumentNullException(nameof(processorRepository));
        RamRepository = ramRepository ?? throw new ArgumentNullException(nameof(ramRepository));
        SsdRepository = ssdRepository ?? throw new ArgumentNullException(nameof(ssdRepository));
        SystemUnitCaseRepository = systemUnitCaseRepository ??
                                   throw new ArgumentNullException(nameof(systemUnitCaseRepository));
        VideoCardRepository = videoCardRepository ?? throw new ArgumentNullException(nameof(videoCardRepository));
        WiFiRepository = wiFiRepository ?? throw new ArgumentNullException(nameof(wiFiRepository));
    }

    public ComponentRepository<CoolingSystem> CoolingRepository { get; } = new();
    public ComponentRepository<BIOS> BiosRepository { get; } = new();
    public ComponentRepository<HDD> HddRepository { get; } = new();
    public ComponentRepository<MotherBoard> MotherBoardRepository { get; } = new();
    public ComponentRepository<PowerUnit> PowerUnitRepository { get; } = new();
    public ComponentRepository<Processor> ProcessorRepository { get; } = new();
    public ComponentRepository<RAM> RamRepository { get; } = new();
    public ComponentRepository<SSD> SsdRepository { get; } = new();
    public ComponentRepository<SystemUnitCase> SystemUnitCaseRepository { get; } = new();
    public ComponentRepository<VideoCard> VideoCardRepository { get; } = new();
    public ComponentRepository<WiFiAdapter> WiFiRepository { get; } = new();
}