using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValueEventListener<T> : MonoBehaviour
{
    [SerializeField] private List<ValueEvent<T>> _gameEvents = new();
    [SerializeField] private UnityEvent<T> _unityEvent;

    private void OnEnable()
    {
        foreach (ValueEvent<T> gameEvent in _gameEvents)
            gameEvent.Register(this);
    }

    private void OnDisable()
    {
        foreach (ValueEvent<T> gameEvent in _gameEvents)
            gameEvent.Unregister(this);
    }

    public void Rise(T value) => _unityEvent?.Invoke(value);
}
