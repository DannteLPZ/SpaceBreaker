using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private List<GameEvent> _gameEvents = new();
    [SerializeField] private UnityEvent _unityEvent;

    private void OnEnable()
    {
        foreach (GameEvent gameEvent in _gameEvents)
            gameEvent.Register(this);
    }

    private void OnDisable()
    {
        foreach (GameEvent gameEvent in _gameEvents)
            gameEvent.Unregister(this);
    }

    public void Rise() => _unityEvent?.Invoke();
}
