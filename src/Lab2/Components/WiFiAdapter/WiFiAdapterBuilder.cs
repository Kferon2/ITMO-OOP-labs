using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _name;
    private PciE? _pciE;
    private string? _wifiStandard;
    private bool _bluetoothModule;
    private int? _powerConsumption;

    public IWiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IWiFiAdapterBuilder WithWiFiStandard(string wifiStandard)
    {
        _wifiStandard = wifiStandard;
        return this;
    }

    public IWiFiAdapterBuilder WithPciE(PciE pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IWiFiAdapterBuilder WithBlueToothModule(bool blueToothModule)
    {
        _bluetoothModule = blueToothModule;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IWiFiAdapterBuilder Direct(WiFiAdapter component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithPciE(component.PciE)
            .WithPowerConsumption(component.PowerConsumption)
            .WithWiFiStandard(component.WiFiStandard)
            .WithBlueToothModule(component.BluetoothModule);
        return this;
    }

    public WiFiAdapter Build()
    {
        return new Components.WiFiAdapter.WiFiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wifiStandard ?? throw new ArgumentNullException(nameof(_wifiStandard)),
            _pciE ?? throw new ArgumentNullException(nameof(_pciE)),
            _bluetoothModule,
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}