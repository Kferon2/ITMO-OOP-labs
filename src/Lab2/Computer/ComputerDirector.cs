using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer;

public class ComputerDirector : IComputerDirector
{
    public Computer CreateComputer(StorageRepository storage, Config config, IComputerBuilder builder)
    {
        if (storage == null) throw new ArgumentNullException(nameof(storage));

        if (config == null) throw new ArgumentNullException(nameof(config));

        if (builder == null) throw new ArgumentNullException(nameof(builder));

        builder.WithProcessor(storage.ProcessorRepository.GetComponent(config.ProcessorName))
            .WithCase(storage.SystemUnitCaseRepository.GetComponent(config.SystemUnitCaseName))
            .WithMotherBoard(storage.MotherBoardRepository.GetComponent(config.MotherBoardName))
            .WithCoolingSystem(storage.CoolingRepository.GetComponent(config.CoolingName))
            .WithPowerUnit(storage.PowerUnitRepository.GetComponent(config.PowerUnitName))
            .WithWiFiAdapter(storage.WiFiRepository.GetComponent(config.WiFiAdapterName))
            .WithBIOS(storage.BiosRepository.GetComponent(config.BIOSName))
            .WithRAM(storage.RamRepository.GetComponent(config.RAMName));
        foreach (string name in config.VideoCardNames)
            builder.AddVideoCard(storage.VideoCardRepository.GetComponent(name));

        foreach (string name in config.HDDNames)
            builder.AddHDD(storage.HddRepository.GetComponent(name) ?? throw new InvalidOperationException());

        foreach (string name in config.SSDNames)
            builder.AddSSD(storage.SsdRepository.GetComponent(name) ?? throw new InvalidOperationException());

        return builder.Build();
    }
}