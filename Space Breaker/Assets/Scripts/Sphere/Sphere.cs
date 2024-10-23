using UnityEngine;

public class Sphere : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _sphereRb;

    [Header("Values")]
    [SerializeField] private LayerMask _bouncingLayer;
    [SerializeField] private float _sphereSpeed;
    [SerializeField] private Vector3 _sphereOffset;

    private Vector2 _normalizedVelocity;
    private Transform _playerTransform;

    private void Start() => _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    public void LaunchSphere(float angle)
    {
        float x = -Mathf.Sin(angle);
        float y = Mathf.Cos(angle);
        Vector2 direction = new(x, y);
        _sphereRb.velocity = _sphereSpeed * direction.normalized;
        _normalizedVelocity = _sphereRb.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(_bouncingLayer, 2))
        {
            //Get normal to know impact direction
            Vector2 normal = collision.GetContact(0).normal;
            Vector2 newVelocity = _normalizedVelocity;

            //Define switch in X axis
            if (Mathf.Sign(normal.x) != Mathf.Sign(_normalizedVelocity.x) && normal.x != 0.0f)
                newVelocity.x *= -1.0f;

            //Define switch in Y axis
            if (Mathf.Sign(normal.y) != Mathf.Sign(_normalizedVelocity.y) && normal.y != 0.0f)
                newVelocity.y *= -1.0f;

            collision.gameObject.TryGetComponent(out Rigidbody2D rb);
            if (rb != null)
                newVelocity += rb.velocity.normalized;

            _sphereRb.velocity = _sphereSpeed * newVelocity.normalized;
            _normalizedVelocity = _sphereRb.velocity.normalized;

            collision.gameObject.TryGetComponent(out Block block);
            if (block != null)
                block.HitBlock();
        }
    }

    public void ResetSphere() => transform.position = _playerTransform.position + _sphereOffset;
    public void StopSphere() => _sphereRb.velocity = Vector2.zero;
}
