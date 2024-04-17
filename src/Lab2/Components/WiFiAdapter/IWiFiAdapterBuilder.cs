using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithName(string name);

    IWiFiAdapterBuilder WithWiFiStandard(string wifiStandard);

    IWiFiAdapterBuilder WithPciE(PciE pciE);

    IWiFiAdapterBuilder WithBlueToothModule(bool blueToothModule);

    IWiFiAdapterBuilder WithPowerConsumption(int powerConsumption);

    IWiFiAdapterBuilder Direct(WiFiAdapter component);

    WiFiAdapter Build();
}