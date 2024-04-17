using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public interface IValidator
{
    public ValidationResult Validate(Computer.Computer computer);
}