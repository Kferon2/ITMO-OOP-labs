using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiPossibleFormats
{
    public IEnumerable<string> Formats { get; } =
        new List<string>() { "1G", "2G", "3G", "4G", "5G" };
}