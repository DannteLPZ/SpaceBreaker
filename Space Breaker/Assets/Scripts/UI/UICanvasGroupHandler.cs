using UnityEngine;
using UnityEngine.EventSystems;

public class UICanvasGroupHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void ShowCanvasGroup(GameObject firstSelected = null)
    {
        HandleGroupVisibility(true);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void HideCanvasGroup() => HandleGroupVisibility(false);
    public void ToggleCanvasGroup() => HandleGroupVisibility(!_canvasGroup.interactable);
    private void HandleGroupVisibility(bool active)
    {
        _canvasGroup.alpha = active ? 1.0f : 0.0f;
        _canvasGroup.interactable = active;
        _canvasGroup.blocksRaycasts = active;
    }

}
