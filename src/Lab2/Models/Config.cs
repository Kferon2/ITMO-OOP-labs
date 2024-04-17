using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Config
{
    public Config(
        string biosName,
        string coolingName,
        string motherBoardName,
        string powerUnitName,
        string processorName,
        string ramName,
        string systemUnitCaseName,
        string wiFiAdapterName,
        IReadOnlyCollection<string> hddNames,
        IReadOnlyCollection<string> ssdNames,
        IReadOnlyCollection<string> videoCardNames)
    {
        BIOSName = biosName;
        CoolingName = coolingName;
        MotherBoardName = motherBoardName;
        PowerUnitName = powerUnitName;
        ProcessorName = processorName;
        RAMName = ramName;
        SystemUnitCaseName = systemUnitCaseName;
        WiFiAdapterName = wiFiAdapterName;
        HDDNames = hddNames;
        SSDNames = ssdNames;
        VideoCardNames = videoCardNames;
    }

    public string BIOSName { get; }

    public string CoolingName { get; }

    public string MotherBoardName { get; }

    public string PowerUnitName { get; }

    public string ProcessorName { get; }

    public string RAMName { get; }

    public string SystemUnitCaseName { get; }

    public string WiFiAdapterName { get; }

    public IReadOnlyCollection<string> HDDNames { get; }

    public IReadOnlyCollection<string> SSDNames { get; }

    public IReadOnlyCollection<string> VideoCardNames { get; }
}