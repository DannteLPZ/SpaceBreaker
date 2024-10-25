using TMPro;
using UnityEngine;

public class UITextSet : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text _text;

    [Header("Values")]
    [SerializeField] private string _startingString;

    public void SetText(int value) => _text.text = _startingString + value;
}
