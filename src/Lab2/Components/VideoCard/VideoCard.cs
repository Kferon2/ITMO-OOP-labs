using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCard;

public class VideoCard : IComponent
{
    public VideoCard(
        string name,
        int height,
        int length,
        int videoMemoryAmount,
        PciE pciE,
        int chipFrequency,
        int powerConsumption)
    {
        new VideoCardFormatValidator().Validate(
            name,
            height,
            length,
            videoMemoryAmount,
            pciE,
            chipFrequency,
            powerConsumption);

        Name = name;
        Height = height;
        Length = length;
        VideoMemoryAmount = videoMemoryAmount;
        PciE = pciE;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public int Height { get; }

    public int Length { get; }

    public int VideoMemoryAmount { get; }

    public PciE PciE { get; }

    public int ChipFrequency { get; }

    public int PowerConsumption { get; }
}