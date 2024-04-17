using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, string wiFiStandard, PciE pciE, int powerConsumption)
    {
        if (new WiFiPossibleFormats().Formats.All(n => wiFiStandard != n))
            throw new BadStringFormatException("Forbidden Wi-Fi format");

        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden Wi-Fi adapter name format");

        if (powerConsumption < 0) throw new NegativeIntArgumentException("Power consumption can't be negative");

        if (pciE == null)
            throw new ArgumentNullException(nameof(pciE));

        return true;
    }
}