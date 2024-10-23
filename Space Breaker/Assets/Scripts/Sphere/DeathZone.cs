using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private LayerMask _sphereLayer;

    [Header("Events")]
    [SerializeField] private GameEvent _onSphereLost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(_sphereLayer, 2))
            _onSphereLost.Invoke();
    }
}
