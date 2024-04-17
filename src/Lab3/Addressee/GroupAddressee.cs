using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    public GroupAddressee(IReadOnlyCollection<IAddressee> addressees)
    {
        Addressees = addressees ?? throw new ArgumentNullException(nameof(addressees));
    }

    public IReadOnlyCollection<IAddressee> Addressees { get; } = new List<IAddressee>();

    public void GetMessage(Message message)
    {
        foreach (IAddressee addressee in Addressees) addressee.GetMessage(message);
    }
}