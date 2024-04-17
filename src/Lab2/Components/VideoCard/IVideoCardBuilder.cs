using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder WithName(string name);

    IVideoCardBuilder WithHeight(int height);

    IVideoCardBuilder WithLength(int length);

    IVideoCardBuilder WithVideoMemoryAmount(int videoMemoryAmount);

    IVideoCardBuilder WithPciE(PciE pciE);

    IVideoCardBuilder WithChipFrequency(int chipFrequency);

    IVideoCardBuilder WithPowerConsumption(int powerConsumption);

    IVideoCardBuilder Direct(VideoCard component);

    VideoCard Build();
}