using UnityEngine;
using UnityEngine.UI;

public class UILevelSelector : MonoBehaviour
{
    [SerializeField] private Button _levelSelector;
    [SerializeField] private int _requiredLevel;

    private void Start()
    {
        _levelSelector.interactable = PlayerPrefs.GetInt("UnlockedLevel", 1) >= _requiredLevel;
    }
}
