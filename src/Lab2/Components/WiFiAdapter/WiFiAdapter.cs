using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiAdapter : IComponent
{
    public WiFiAdapter(string name, string wiFiStandard, PciE pciE, bool bluetoothModule, int powerConsumption)
    {
        new WiFiFormatValidator().Validate(name, wiFiStandard, pciE, powerConsumption);
        Name = name;
        WiFiStandard = wiFiStandard;
        PciE = pciE;
        BluetoothModule = bluetoothModule;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public string WiFiStandard { get; }

    public PciE PciE { get; }

    public bool BluetoothModule { get; }

    public int PowerConsumption { get; }
}