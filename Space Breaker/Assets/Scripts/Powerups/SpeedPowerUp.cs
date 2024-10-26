using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float _extraSpeed;
    [SerializeField] private float _duration;
    private PlayerMovement _playerMovement;
    protected override void StartPowerUp(Collider2D collision)
    {
        collision.TryGetComponent(out _playerMovement);
        if (_playerMovement != null) _playerMovement.SetExtraSpeed(_extraSpeed, _duration); 
        Destroy(gameObject);
    }
}
