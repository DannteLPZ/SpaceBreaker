using UnityEngine;

public class Sphere : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _sphereRb;

    [Header("Values")]
    [SerializeField] private LayerMask _bouncingLayer;
    [SerializeField] private float _sphereSpeed;

    private Vector2 _normalizedVelocity;

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

            _sphereRb.velocity = _sphereSpeed * newVelocity;
            _normalizedVelocity = _sphereRb.velocity.normalized;

            collision.gameObject.TryGetComponent(out Block block);
            if (block != null)
                block.HitBlock();
        }
    }

    public void StopSphere() => _sphereRb.velocity = Vector2.zero;
}
