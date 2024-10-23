using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    [SerializeField] private TMP_Text _livesText;
    private void Start()
    {
        SetLivesText();
    }

    public void SetLivesText() => _livesText.text = "x " + GameManager.Instance.Lives;
}
