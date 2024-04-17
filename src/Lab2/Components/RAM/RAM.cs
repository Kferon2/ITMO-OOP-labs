using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAM;

public class RAM : IComponent
{
    public RAM(
        string name,
        int memoryCapacity,
        IList<JDEC> supportedJdecs,
        MotherBoardFormFactor formFactor,
        IList<XMPProfile.XMPProfile> xmpProfiles,
        int powerConsumption,
        DDR ddr)
    {
        new RAMFormatValidator().Validate(
            name,
            memoryCapacity,
            supportedJdecs,
            formFactor,
            xmpProfiles,
            powerConsumption,
            ddr);
        Ddr = ddr;
        Name = name;
        MemoryCapacity = memoryCapacity;
        SupportedJdecs = supportedJdecs;
        FormFactor = formFactor;
        XmpProfiles = xmpProfiles;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public int MemoryCapacity { get; }

    public IList<JDEC> SupportedJdecs { get; }

    public MotherBoardFormFactor FormFactor { get; }

    public IList<XMPProfile.XMPProfile> XmpProfiles { get; }

    public DDR Ddr { get; }

    public int PowerConsumption { get; }
}