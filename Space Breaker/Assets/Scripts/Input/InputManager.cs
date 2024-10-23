using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent _onLaunch;
    [SerializeField] private GameEvent _onPause;

    private PlayerInput _playerInput;
    private InputAction _move;
    private InputAction _launch;
    private InputAction _pause;

    private float _moveValue;
    public float MoveValue => _moveValue;

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _playerInput = new();
        _move = _playerInput.Gameplay.Move;
        _launch = _playerInput.Gameplay.Launch;
        _pause = _playerInput.Gameplay.Pause;

        _launch.performed += x => _onLaunch.Invoke();
        _pause.performed += x => _onPause.Invoke();

        _playerInput.Enable();
    }

    private void OnEnable() => _playerInput?.Enable();
    private void OnDisable() => _playerInput?.Disable();

    private void Update() => _moveValue = _move.ReadValue<float>();
}
