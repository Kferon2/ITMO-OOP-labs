using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private string? _name;
    private int? _height;
    private int? _length;
    private int? _videoMemoryAmount;
    private PciE? _pciE;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public IVideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IVideoCardBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public IVideoCardBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public IVideoCardBuilder WithVideoMemoryAmount(int videoMemoryAmount)
    {
        _videoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public IVideoCardBuilder WithPciE(PciE pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IVideoCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IVideoCardBuilder Direct(VideoCard component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithHeight(component.Height)
            .WithLength(component.Length)
            .WithPciE(component.PciE)
            .WithVideoMemoryAmount(component.VideoMemoryAmount)
            .WithChipFrequency(component.ChipFrequency)
            .WithPowerConsumption(component.PowerConsumption);
        return this;
    }

    public VideoCard Build()
    {
        return new Components.VideoCard.VideoCard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _length ?? throw new ArgumentNullException(nameof(_name)),
            _videoMemoryAmount ?? throw new ArgumentNullException(nameof(_videoMemoryAmount)),
            _pciE ?? throw new ArgumentNullException(nameof(_pciE)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}