using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SystemUnitCase;

public interface ISystemUnitCaseBuilder
{
    ISystemUnitCaseBuilder WithName(string name);

    ISystemUnitCaseBuilder WithMaximalVideoCardHeight(int maximalVideoCardWidth);

    ISystemUnitCaseBuilder WithMaximalVideoCardLength(int maximalVideoCardLength);

    ISystemUnitCaseBuilder AddSupportedFormFactor(MotherBoardFormFactor factor);

    ISystemUnitCaseBuilder WithLength(int length);

    ISystemUnitCaseBuilder WithWidth(int width);

    ISystemUnitCaseBuilder WidthHeight(int height);

    SystemUnitCase Build();
}