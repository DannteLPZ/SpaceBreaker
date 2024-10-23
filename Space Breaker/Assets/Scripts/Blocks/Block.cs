using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private BlockType _blockType;
    [SerializeField] private BlockRuntimeSet _runtimeSet;

    private int _resistance;

    private void OnEnable() => _runtimeSet.Add(this);
    private void OnDisable() => _runtimeSet.Remove(this);

    private void Start()
    {
        _resistance = _blockType.Resistance;
    }

    public void HitBlock()
    {
        _resistance--;
        if(_resistance <= 0) Destroy(gameObject);
    }
}
