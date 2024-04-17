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

public interface IComputerBuilder
{
    IComputerBuilder WithMotherBoard(MotherBoard? motherBoard);

    IComputerBuilder WithProcessor(Processor? processor);

    IComputerBuilder WithBIOS(BIOS? bios);

    IComputerBuilder WithCoolingSystem(CoolingSystem? coolingSystem);

    IComputerBuilder WithRAM(RAM? ram);

    IComputerBuilder AddVideoCard(VideoCard? videoCard);

    IComputerBuilder AddSSD(SSD ssd);

    IComputerBuilder AddHDD(HDD hdd);

    IComputerBuilder WithCase(SystemUnitCase? unitCase);

    IComputerBuilder WithPowerUnit(PowerUnit? powerUnit);

    IComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);

    Computer Build();
}