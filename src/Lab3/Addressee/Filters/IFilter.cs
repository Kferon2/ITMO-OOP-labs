using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Filters;

public interface IFilter
{
    bool Filtrate(Message message);
}