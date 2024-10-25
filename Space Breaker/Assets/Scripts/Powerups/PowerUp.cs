using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PowerUpSO _powerupSO;
    [SerializeField] private Rigidbody2D _powerUpRb;

    private void Start() => _powerUpRb.velocity = 2.0f * Vector2.down;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            _powerupSO.ActivatePowerup();
            Destroy(gameObject);
        }
    }
}
