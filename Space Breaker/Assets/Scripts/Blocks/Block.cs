using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _particleEffects;

    [Header("Values")]
    [SerializeField] private BlockType _blockType;
    [SerializeField] private BlockRuntimeSet _runtimeSet;
    [SerializeField] private PowerUpSet _powerUpSet;

    [Header("GameEvents")]
    [SerializeField] private GameEvent _onBlockHit;

    private int _resistance;
    private Material _material;
    private ParticleSystem _particles;
    private GameObject _powerUp;

    private void OnEnable() => _runtimeSet.Add(this);
    private void OnDisable() => _runtimeSet.Remove(this);

    private void Start()
    {
        _resistance = _blockType.Resistance;

        //Get components for visuals
        _material = GetComponent<Renderer>().material;
        _material.SetColor("_BlockColor", _blockType.Colors[0]);
        _particles = Instantiate(_particleEffects, transform.position, Quaternion.identity, transform)
                        .GetComponent<ParticleSystem>();

        //Check if powerup will be given on destroy
        _powerUp = _powerUpSet.ChancePowerUp();
        if(_powerUp != null)
        {
            _powerUp = Instantiate(_powerUp, transform.position, Quaternion.identity, transform);
            _powerUp.SetActive(false);
        }
    }

    public void HitBlock()
    {
        _resistance--;
        _onBlockHit.Invoke();
        if (_resistance > 0)
        {
            UpdateMaterial();
        }
        else
        {
            _particles.gameObject.transform.parent = null;
            _particles.Play();
            if(_powerUp != null)
            {
                _powerUp.SetActive(true);
                _powerUp.transform.parent = null;
            }
            _runtimeSet.Remove(this);
            _runtimeSet.BlockManager.CheckAmountLeft();
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
