namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;

public interface IBIOSBuilder
{
    IBIOSBuilder WithName(string name);

    IBIOSBuilder WithType(string type);

    IBIOSBuilder WithVersion(string version);

    IBIOSBuilder AddSupportedProcessor(string processor);

    IBIOSBuilder Direct(BIOS component);

    BIOS Build();
}