using UnityEngine;

public class ResetBackground : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _range;
    private Vector2 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.down);
    }

    private void LateUpdate()
    {
        if (transform.position.y < _startPos.y - _range)
        {
            transform .position = _startPos;
        }
    }
}
