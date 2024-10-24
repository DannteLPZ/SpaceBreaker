using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _playerRb;

    [Header("Values")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _xRange;

    private Vector3 _startPosition;
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
            _playerRb.velocity = InputManager.Instance.MoveValue * _moveSpeed * Vector2.right;
    }

    public void AllowMovement() => _isEnabled = true;

    public void ForbidMovement()
    {
        _isEnabled = false;
        _playerRb.velocity = Vector2.zero;
    }


}
