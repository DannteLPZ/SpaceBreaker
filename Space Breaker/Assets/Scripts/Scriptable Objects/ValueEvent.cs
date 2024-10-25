using System.Collections.Generic;
using UnityEngine;

public class ValueEvent<T> : ScriptableObject
{
    private List<ValueEventListener<T>> _listeners = new();
    public List<ValueEventListener<T>> Listeners => _listeners;

    public void Register(ValueEventListener<T> listener)
    {
        if (Listeners.Contains(listener) == false) _listeners.Add(listener);
    }

    public void Unregister(ValueEventListener<T> listener)
    {
        if (Listeners.Contains(listener) == true) _listeners.Remove(listener);
    }

    public void Invoke(T value)
    {
        foreach (ValueEventListener<T> listener in _listeners)
            listener.Rise(value);
    }
}
