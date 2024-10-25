using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Value Events")]
    [SerializeField] private IntEvent _onScoreUpdated;

    private int _score;

    public void HitBlock()
    {
        _score += 100;
        _onScoreUpdated.Invoke(_score);
    }

    public void ToggleTimeScale() => HandleGameTime(Time.timeScale == 1.0f);
    private void HandleGameTime(bool paused) => Time.timeScale = paused ? 0.0f : 1.0f;
}
