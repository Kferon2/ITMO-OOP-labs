using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
    where T : IComponent
{
    T? GetComponent(string name);
    void Add(T component);
    void Update(T component);
    void Delete(string name);

    void Clear();
}