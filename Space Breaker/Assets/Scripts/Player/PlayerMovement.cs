using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string SFX_SPEEDUP = "SFX_SpeedUp";

    [Header("Components")]
    [SerializeField] private Rigidbody2D _playerRb;

    [Header("Values")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _xRange;

    [Header("Value Events")]
    [SerializeField] private StringEvent _audioPlayed;

    private Vector3 _startPosition;
    private float _extraSpeed;
    private bool _isEnabled;

    private void Start() => _startPosition = transform.position;

    private void Update()
    {
        float limitX = transform.position.x;
        if(transform.position.x < _startPosition.x - _xRange)
            limitX = _startPosition.x - _xRange;
        else if (transform.position.x > _startPosition.x + _xRange)
            limitX = _startPosition.x + _xRange;
        transform.position = new(limitX, _startPosition.y, _startPosition.z);

    }

    private void FixedUpdate()
    {
        if (_isEnabled == true)
            _playerRb.velocity = InputManager.Instance.MoveValue * (_moveSpeed + _extraSpeed) * Vector2.right;
    }

    public void AllowMovement() => _isEnabled = true;

    public void ForbidMovement()
    {
        _isEnabled = false;
        _playerRb.velocity = Vector2.zero;
    }

    public void SetExtraSpeed(float extraSpeed, float duration)
    {
        StopAllCoroutines();
        _extraSpeed = extraSpeed;
        _audioPlayed.Invoke(SFX_SPEEDUP);
        StartCoroutine(ResetSpeed(duration));
    }

    private IEnumerator ResetSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        _extraSpeed = 0.0f;
    }
}
