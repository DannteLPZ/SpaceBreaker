using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private LayerMask _sphereLayer;
    [SerializeField] private LayerMask _powerUpLayer;

    [Header("Events")]
    [SerializeField] private GameEvent _onSphereLost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(_sphereLayer, 2))
            _onSphereLost.Invoke();
        else if (collision.gameObject.layer == Mathf.Log(_powerUpLayer, 2))
            Destroy(collision.gameObject);
    }
}
