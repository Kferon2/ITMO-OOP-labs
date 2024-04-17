using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.MotherBoard;

public class MotherBoardFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        Sockets sockets,
        PciE pciE,
        Sata sata,
        MotherBoardChipSet chipSet,
        DDR ddr,
        int ramTablesCount,
        MotherBoardFormFactor formFactor,
        BIOS.BIOS bios)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden motherboard name format");

        if (ramTablesCount < 0) throw new NegativeIntArgumentException("Ram tables can't be negative");

        if (sockets == null) throw new ArgumentNullException(nameof(sockets));
        if (pciE == null) throw new ArgumentNullException(nameof(pciE));
        if (sata == null) throw new ArgumentNullException(nameof(sata));
        if (chipSet == null) throw new ArgumentNullException(nameof(chipSet));
        if (ddr == null) throw new ArgumentNullException(nameof(ddr));
        if (formFactor == null) throw new ArgumentNullException(nameof(formFactor));
        if (bios == null) throw new ArgumentNullException(nameof(bios));

        return true;
    }
}