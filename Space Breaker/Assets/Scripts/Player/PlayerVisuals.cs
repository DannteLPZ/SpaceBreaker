using System;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator _boosterAnimator;
    [SerializeField] private Animator _bouncerAnimator;
    [SerializeField] private SpriteRenderer _boosterRenderer;
    [SerializeField] private Rigidbody2D _playerRb;

    [Header("Values")]
    [SerializeField] private LayerMask _sphereLayer;

    private void Update()
    {
        _boosterAnimator.SetBool("Active", _playerRb.velocity.sqrMagnitude > 0);
        _boosterRenderer.flipX = _playerRb.velocity.x < 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == Mathf.Log(_sphereLayer, 2))
            _bouncerAnimator.SetTrigger("Bounce");
    }
}
