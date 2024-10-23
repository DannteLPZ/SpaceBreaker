using UnityEngine;
using UnityEngine.InputSystem;

public class SphereManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Sphere _sphere;
    [SerializeField] private GameObject _arrow;

    [Header("Values")]
    [SerializeField] private float _rotationSpeed;

    //Define input actions for aiming and launching
    private PlayerInput _playerInput;
    private InputAction _move;
    private InputAction _launch;

    private Vector2 _startingPosition;

    private float _launchAngle;
    private bool _hasLaunched;

    private void Awake()
    {
        _playerInput = new();
        _move = _playerInput.Gameplay.Move;
        _launch = _playerInput.Gameplay.Launch;

        _launch.performed += x => Launch();

        _playerInput.Enable();
    }

    private void Start() => _startingPosition = _sphere.transform.position;

    private void Update()
    {
        if(_hasLaunched == false)
        {
            ModifyAngle();
            _arrow.transform.rotation = Quaternion.Euler(_launchAngle * Vector3.forward);
        }
    }

    private void Launch()
    {
        if(_hasLaunched == false)
        {
            _sphere.LaunchSphere(_launchAngle * Mathf.Deg2Rad);
            _hasLaunched = true;
            _arrow.SetActive(false);
        }
    }

    private void ModifyAngle()
    {
        float inputDirection = _move.ReadValue<float>();
        _launchAngle -= inputDirection * _rotationSpeed * Time.deltaTime;
        _launchAngle = Mathf.Clamp(_launchAngle, -60.0f, 60.0f); 
    }

    public void ResetLaunch()
    {
        _sphere.StopSphere();
        _arrow.SetActive(true);
        _hasLaunched = false;
    }
}
