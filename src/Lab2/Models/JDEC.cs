using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class JDEC
{
    public JDEC(int frequency, int voltage)
    {
        if (frequency < 0) throw new NegativeIntArgumentException("Frequency can't be negative");

        if (voltage < 0) throw new NegativeIntArgumentException("Voltage can't be negative");

        Frequency = frequency;
        Voltage = voltage;
    }

    public int Frequency { get; }

    public int Voltage { get; }
}