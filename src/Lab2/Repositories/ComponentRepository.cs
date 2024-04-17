using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class ComponentRepository<T> : IRepository<T>
    where T : IComponent
{
    private IList<T> _components = new List<T>();

    public ComponentRepository()
    {
        _components = new List<T>();
    }

    public ComponentRepository(IList<T> components)
    {
        _components = components;
    }

    public T? GetComponent(string name)
    {
        return _components.FirstOrDefault(component => component.Name == name);
    }

    public void Add(T component)
    {
        _components.Add(component);
    }

    public void Update(T component)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }

        foreach (T varComponent in _components)
        {
            if (varComponent.Name != component.Name) continue;
            _components.Remove(varComponent);
            _components.Add(component);
        }
    }

    public void Delete(string name)
    {
        foreach (T component in _components)
        {
            if (component.Name == name)
            {
                _components.Remove(component);
            }
        }
    }

    public void Clear()
    {
        _components.Clear();
    }
}