using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int _startingLives;

    [Header("Game Events")]
    [SerializeField] private GameEvent _onLaunchReset;
    [SerializeField] private GameEvent _onGameOver;

    [Header("Value Events")]
    [SerializeField] private IntEvent _onLivesUpdated;

    private int _lives;
    public int Lives => _lives;

    private void Start()
    {
        _lives = _startingLives;
        _onLivesUpdated.Invoke(_lives);
    }

    public void AddLife()
    {
        _lives++;
        _onLivesUpdated.Invoke(_lives);
    }

    public void RemoveLife()
    {
        _lives--;
        _onLivesUpdated.Invoke(_lives);
        if (_lives == 0)
            _onGameOver.Invoke();
        else
            _onLaunchReset.Invoke();
    }
}
