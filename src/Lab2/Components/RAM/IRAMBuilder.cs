using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAM;

public interface IRAMBuilder
{
    IRAMBuilder WithName(string name);

    IRAMBuilder WithMemoryCapacity(int memoryCapacity);

    IRAMBuilder WithFormFactor(MotherBoardFormFactor formFactor);

    IRAMBuilder WithDDR(DDR ddr);

    IRAMBuilder AddJDEC(JDEC jdec);

    IRAMBuilder AddXMP(XMPProfile.XMPProfile xmpProfile);

    IRAMBuilder WithPowerConsumption(int powerConsumption);

    IRAMBuilder Direct(RAM component);

    RAM Build();
}