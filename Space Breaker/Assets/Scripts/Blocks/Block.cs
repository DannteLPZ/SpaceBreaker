using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject _particleEffects;

    [Header("Values")]
    [SerializeField] private BlockType _blockType;
    [SerializeField] private BlockRuntimeSet _runtimeSet;

    private int _resistance;
    private Material _material;

    private void OnEnable() => _runtimeSet.Add(this);
    private void OnDisable() => _runtimeSet.Remove(this);

    private void Start()
    {
        _resistance = _blockType.Resistance;
        _material = GetComponent<Renderer>().material;
        _material.SetColor("_BlockColor", _blockType.Colors[0]);
    }

    public void HitBlock()
    {
        _resistance--;
        GameManager.Instance.AddScore();
        if (_resistance > 0)
        {
            UpdateMaterial();
        }
        else
        {
            Instantiate(_particleEffects, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }

    private void UpdateMaterial()
    {
        Color newColor = _blockType.Colors[_blockType.Resistance - _resistance];
        _material.SetColor("_BlockColor", newColor);
        
        float crackProgress;
        if (_blockType.Resistance > 1)
        {
            crackProgress = _blockType.Resistance - (float)_resistance;
            _material.SetFloat("_CrackProgress", crackProgress);
        }

    }
}
