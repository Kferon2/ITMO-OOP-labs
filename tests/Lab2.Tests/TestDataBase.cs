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
using Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestDataBase
{
    public TestDataBase()
    {
        Storage.BiosRepository.Add(new BIOSBuilder()
            .WithName("Super")
            .WithType("Ami")
            .WithVersion("2.0")
            .AddSupportedProcessor("Intel Core i5")
            .AddSupportedProcessor("Intel Core i3")
            .Build());

        Storage.BiosRepository.Add(new BIOSBuilder()
            .WithName("Mega")
            .WithType("Ami")
            .WithVersion("3.0")
            .AddSupportedProcessor("Intel Core i5")
            .AddSupportedProcessor("Intel Core i3")
            .AddSupportedProcessor("Intel Core i9")
            .Build());

        Storage.CoolingRepository.Add(new CoolingSystemBuilder()
            .WithName("PCcooler")
            .WithHeight(3)
            .WithLength(4)
            .WithWidth(2)
            .WithTdp(20)
            .WithSockets(new Sockets("LGA", 1))
            .Build());

        Storage.CoolingRepository.Add(new CoolingSystemBuilder()
            .WithName("DeepCool")
            .WithHeight(4)
            .WithLength(4)
            .WithWidth(4)
            .WithTdp(40)
            .WithSockets(new Sockets("LGA", 1))
            .Build());

        Storage.HddRepository.Add(new HDDBuilder()
            .WithName("HDD 3")
            .WithMemoryCapacity(30)
            .WithSpindleSpeed(228)
            .WithPowerConsumption(60)
            .WithSata(new Sata("Sata v.3.0", 1))
            .Build());

        Storage.HddRepository.Add(new HDDBuilder()
            .WithName("HDD 4")
            .WithMemoryCapacity(40)
            .WithSpindleSpeed(239)
            .WithPowerConsumption(80)
            .WithSata(new Sata("Sata v.4.0", 1))
            .Build());

        Storage.MotherBoardRepository.Add(new MotherBoardBuilder()
            .WithName("ATX")
            .WithSockets(new Sockets("LGA", 4))
            .WithSata(new Sata("Sata v.3.0", 2))
            .WithFormFactor(new MotherBoardFormFactor("EATX", 1, 1, 1))
            .WithChipSet(new MotherBoardChipSet(new List<int>() { 2000, 4400, 3200 }, true))
            .WithPciE(new PciE("PCIe2.0", 15))
            .WithDDR(new DDR("DDR4"))
            .WithRamTablesCount(3)
            .WithBIOS(Storage.BiosRepository.GetComponent("Super"))
            .Build());

        Storage.PowerUnitRepository.Add(new PowerUnitBuilder()
            .WithName("Crypton")
            .WithPeakLoad(100)
            .Build());

        Storage.PowerUnitRepository.Add(new PowerUnitBuilder()
            .WithName("Baza")
            .WithPeakLoad(500)
            .Build());

        Storage.ProcessorRepository.Add(new ProcessorBuilder()
            .WithName("Intel Core i5")
            .WithSockets(new Sockets("LGA", 2))
            .WithTdp(21)
            .WithPowerConsumption(90)
            .WithCoreCount(4)
            .WithCoreFrequency(2000)
            .AddSupportedMemoryFrequency(3000)
            .AddSupportedMemoryFrequency(4200)
            .AddSupportedMemoryFrequency(4400)
            .WithBuiltInVideoCore(false)
            .Build());

        Storage.ProcessorRepository.Add(new ProcessorBuilder()
            .WithName("Intel Core i9")
            .WithSockets(new Sockets("LGA", 3))
            .WithTdp(25)
            .WithPowerConsumption(120)
            .WithCoreCount(8)
            .WithCoreFrequency(3000)
            .AddSupportedMemoryFrequency(3200)
            .AddSupportedMemoryFrequency(4400)
            .AddSupportedMemoryFrequency(4600)
            .WithBuiltInVideoCore(true)
            .Build());

        Storage.RamRepository.Add(new RAMBuilder()
            .WithName("RAM v2.0.")
            .WithFormFactor(new MotherBoardFormFactor("EATX", 1, 1, 1))
            .WithMemoryCapacity(50)
            .WithPowerConsumption(65)
            .WithDDR(new DDR("DDR4"))
            .AddJDEC(new JDEC(3000, 20))
            .AddJDEC(new JDEC(2800, 18))
            .AddXMP(new XMPProfileBuilder()
                .WithName("XMP1")
                .WithFrequency(4400)
                .WithVoltage(45)
                .WithTiming("18-18-36-54")
                .Build())
            .Build());

        Storage.RamRepository.Add(new RAMBuilder()
            .WithName("RAM v1.0.")
            .WithFormFactor(new MotherBoardFormFactor("EATX", 1, 1, 1))
            .WithMemoryCapacity(30)
            .WithPowerConsumption(45)
            .WithDDR(new DDR("DDR3"))
            .AddJDEC(new JDEC(2000, 15))
            .AddJDEC(new JDEC(2800, 18))
            .AddXMP(new XMPProfileBuilder()
                .WithName("XMP1")
                .WithFrequency(4400)
                .WithVoltage(45)
                .WithTiming("18-18-36-54")
                .Build())
            .Build());

        Storage.SsdRepository.Add(new SSDBuilder()
            .WithName("SSD v1.0.")
            .WithMemoryCapacity(40)
            .WithPciE(new PciE("PCIe1.0", 6))
            .WithPowerConsumption(10)
            .WithMaximalWorkSpeed(300)
            .Build());

        Storage.SsdRepository.Add(new SSDBuilder()
            .WithName("SSD v2.0.")
            .WithMemoryCapacity(50)
            .WithPciE(new PciE("PCIe2.0", 6))
            .WithPowerConsumption(12)
            .WithMaximalWorkSpeed(350)
            .Build());

        Storage.SystemUnitCaseRepository.Add(new SystemUnitCaseBuilder()
            .WithName("Wolfram")
            .WithLength(10)
            .WithWidth(5)
            .WidthHeight(8)
            .WithMaximalVideoCardLength(3)
            .WithMaximalVideoCardHeight(2)
            .AddSupportedFormFactor(new MotherBoardFormFactor("EATX", 1, 1, 1))
            .Build());

        Storage.VideoCardRepository.Add(new VideoCardBuilder()
            .WithName("RTX 2070")
            .WithHeight(1)
            .WithLength(2)
            .WithPciE(new PciE("PCIe2.0", 4))
            .WithChipFrequency(400)
            .WithPowerConsumption(70)
            .WithVideoMemoryAmount(10)
            .Build());

        Storage.VideoCardRepository.Add(new VideoCardBuilder()
            .WithName("RTX 3090")
            .WithHeight(1)
            .WithLength(3)
            .WithPciE(new PciE("PCIe2.0", 4))
            .WithChipFrequency(800)
            .WithPowerConsumption(90)
            .WithVideoMemoryAmount(25)
            .Build());

        Storage.WiFiRepository.Add(new WiFiAdapterBuilder()
            .WithName("5G")
            .WithPciE(new PciE("PCIe2.0", 1))
            .WithPowerConsumption(5)
            .WithBlueToothModule(true)
            .WithWiFiStandard("5G")
            .Build());
    }

    public StorageRepository Storage { get; } = new();

    public Config FirstTestConfig { get; } = new(
        "Super",
        "DeepCool",
        "ATX",
        "Baza",
        "Intel Core i5",
        "RAM v2.0.",
        "Wolfram",
        "5G",
        new[] { "HDD 3" },
        new[] { "SSD v2.0." },
        new[] { "RTX 2070" });

    public Config SecondTestConfig { get; } = new(
        "Super",
        "DeepCool",
        "ATX",
        "Crypton",
        "Intel Core i5",
        "RAM v2.0.",
        "Wolfram",
        "5G",
        new[] { "HDD 3" },
        new[] { "SSD v2.0." },
        new[] { "RTX 2070" });

    public Config ThirdTestConfig { get; } = new(
        "Super",
        "PCcooler",
        "ATX",
        "Crypton",
        "Intel Core i5",
        "RAM v2.0.",
        "Wolfram",
        "5G",
        new[] { "HDD 3" },
        new[] { "SSD v2.0." },
        new[] { "RTX 2070" });

    public Config FourthTestConfig { get; } = new(
        "Super",
        "PCcooler",
        "ATX",
        "Crypton",
        "Intel Core i9",
        "RAM v1.0.",
        "Wolfram",
        "5G",
        new[] { "HDD 3" },
        new[] { "SSD v2.0." },
        new[] { "RTX 2070" });
}