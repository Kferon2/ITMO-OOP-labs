using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;
namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeProxyFilter : IAddressee
{
    private IAddressee _addressee;

    public AddresseeProxyFilter(IAddressee addressee, IFilter filter)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        Filter = filter ?? throw new ArgumentNullException(nameof(filter));
    }

    public IFilter Filter { get; }

    public void GetMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (Filter.Filtrate(message)) _addressee.GetMessage(message);
    }
}