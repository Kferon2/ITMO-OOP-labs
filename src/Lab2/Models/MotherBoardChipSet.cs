using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MotherBoardChipSet
{
    public MotherBoardChipSet(IReadOnlyCollection<int> supportedFrequences, bool supportXmp)
    {
        SupportedFrequences = supportedFrequences;
        SupportXMP = supportXmp;
    }

    public IReadOnlyCollection<int> SupportedFrequences { get; }

    public bool SupportXMP { get; }
}