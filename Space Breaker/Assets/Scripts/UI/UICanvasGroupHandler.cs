using UnityEngine;

public class UICanvasGroupHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void ShowCanvasGroup() => HandleGroupVisibility(true);
    public void HideCanvasGroup() => HandleGroupVisibility(false);

    private void HandleGroupVisibility(bool active)
    {
        _canvasGroup.alpha = active ? 1.0f : 0.0f;
        _canvasGroup.interactable = active;
        _canvasGroup.blocksRaycasts = active;
    }
}
