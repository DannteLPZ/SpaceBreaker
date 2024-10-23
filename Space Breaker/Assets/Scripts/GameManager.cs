using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private int _startingLives;

    [Header("Events")]
    [SerializeField] private GameEvent _onLaunchReset;
    [SerializeField] private GameEvent _onLivesUpdated;
    [SerializeField] private GameEvent _onGameOver;
    [SerializeField] private GameEvent _onScoreUpdated;

    private int _lives;
    public int Lives => _lives;

    private int _score;
    public int Score => _score;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _lives = _startingLives;
    }

    public void AddLife()
    {
        _lives++;
        _onLivesUpdated.Invoke();
    }

    public void RemoveLife()
    {
        _lives--;
        _onLivesUpdated.Invoke();
        if(_lives == 0)
            _onGameOver.Invoke();
        else
            _onLaunchReset.Invoke();
    }

    public void AddScore()
    {
        _score += 100;
        _onScoreUpdated.Invoke();
    }
}
