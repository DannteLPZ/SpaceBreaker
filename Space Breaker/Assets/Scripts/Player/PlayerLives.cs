using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private const string SFX_LIFE_ADDED = "SFX_LifeAdded";
    private const string SFX_LIFE_LOST = "SFX_LifeLost";
    private const string SFX_GAME_OVER = "SFX_GameOver";

    [Header("Values")]
    [SerializeField] private int _startingLives;

    [Header("Game Events")]
    [SerializeField] private GameEvent _onLaunchReset;
    [SerializeField] private GameEvent _onGameOver;

    [Header("Value Events")]
    [SerializeField] private IntEvent _onLivesUpdated;
    [SerializeField] private StringEvent _onAudioPlayed;

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
        _onAudioPlayed.Invoke(SFX_LIFE_ADDED);
        _onLivesUpdated.Invoke(_lives);
    }

    public void RemoveLife()
    {
        _lives--;
        _onLivesUpdated.Invoke(_lives);
        if (_lives == 0)
        {
            _onAudioPlayed.Invoke(SFX_GAME_OVER);
            _onGameOver.Invoke();
        }
        else
        {
            _onLaunchReset.Invoke();
            _onAudioPlayed.Invoke(SFX_LIFE_LOST);
        }
    }
}
