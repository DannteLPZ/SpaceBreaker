using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event", menuName = "Scriptable Objects/Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new();
    public List<GameEventListener> Listeners => _listeners;

    public void Register(GameEventListener listener)
    {
        if(Listeners.Contains(listener) == false) _listeners.Add(listener);
    }

    public void Unregister(GameEventListener listener)
    {
        if (Listeners.Contains(listener) == true) _listeners.Remove(listener);
    }

    public void Invoke()
    {
        foreach (GameEventListener listener in _listeners)
            listener.Rise();
    }
}
