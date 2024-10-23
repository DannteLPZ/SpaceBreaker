using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private void Start()
    {
        SetScoreText();
    }

    public void SetScoreText() => _scoreText.SetText("Score: {0:0000}", GameManager.Instance.Score);
}
