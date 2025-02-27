using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerVisuals : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator _boosterAnimator;
    [SerializeField] private Animator _bouncerAnimator;
    [SerializeField] private SpriteRenderer _boosterRenderer;
    [SerializeField] private Light2D _boosterLight;
    [SerializeField] private Rigidbody2D _playerRb;

    [Header("Values")]
    [SerializeField] private LayerMask _sphereLayer;

    private void Update()
    {
        _boosterAnimator.SetBool("Active", _playerRb.velocity.sqrMagnitude > 0);
        float lightRotation = _playerRb.velocity.x < 0.0f ? 180.0f : 0.0f;
        _boosterLight.transform.rotation = Quaternion.Euler(0.0f, lightRotation, 0.0f);
        _boosterLight.enabled = _playerRb.velocity.sqrMagnitude > 0;
        _boosterRenderer.flipX = _playerRb.velocity.x < 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == Mathf.Log(_sphereLayer, 2))
            _bouncerAnimator.SetTrigger("Bounce");
    }
}
