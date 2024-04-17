using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ComputerValidator
{
    private readonly CoolingSystemAndUnitCaseValidator _coolingSystemAndUnitCaseValidator = new();
    private readonly BIOSAndProcessorValidator _biosAndProcessorValidator = new();
    private readonly MotherBoardSocketValidator _socketValidator = new();
    private readonly MotherBoardSataValidator _sataValidator = new();
    private readonly MotherBoardPCIEValidator _pcieValidator = new();
    private readonly MotherBoardAndRamValidator _motherBoardAndRamValidator = new();
    private readonly MotherBoardAndUnitCaseValidator _motherBoardAndUnitCaseValidator = new();
    private readonly TDPValidator _tdpValidator = new();
    private readonly VideoCardAndUnitCaseValidator _videoCardAndUnitCaseValidator = new();
    private readonly XMPAndMotherBoardValidator _xmpAndMotherBoardValidator = new();
    private readonly XMPAndProcessorValidator _xmpAndProcessorValidator = new();
    private readonly MemoryValidator _memoryValidator = new();
    private readonly VideoCardValidator _videoCardValidator = new();
    private readonly PowerConsumptionValidator _powerConsumptionValidator = new();

    private bool _isValid;

    private List<string> _comment = new();

    public ComputerValidatorResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        _isValid = _coolingSystemAndUnitCaseValidator.Validate(computer).IsValid &&
                   _biosAndProcessorValidator.Validate(computer).IsValid &&
                   _socketValidator.Validate(computer).IsValid &&
                   _sataValidator.Validate(computer).IsValid && _pcieValidator.Validate(computer).IsValid &&
                   _motherBoardAndRamValidator.Validate(computer).IsValid &&
                   _motherBoardAndUnitCaseValidator.Validate(computer).IsValid &&
                   _videoCardAndUnitCaseValidator.Validate(computer).IsValid &&
                   _xmpAndProcessorValidator.Validate(computer).IsValid &&
                   _xmpAndMotherBoardValidator.Validate(computer).IsValid &&
                   _memoryValidator.Validate(computer).IsValid &&
                   _videoCardValidator.Validate(computer).IsValid;

        if (!_powerConsumptionValidator.Validate(computer).IsValid)
        {
            _comment.Add("Power consumption is bigger than required.");
        }

        if (!_tdpValidator.Validate(computer).IsValid)
        {
            _comment.Add(
                "We refuse warranty obligations due to unsuitable parameters of the cooling system and processor.");
        }

        return new ComputerValidatorResult(_comment, _isValid);
    }
}