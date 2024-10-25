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
    

    private Vector2 _startingPosition;

    private float _launchAngle;
    private bool _hasLaunched;

    private void Update()
    {
        if(_hasLaunched == false)
            ModifyAngle();
    }

    public void Launch()
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
        _launchAngle -= InputManager.Instance.MoveValue * _rotationSpeed * Time.deltaTime;
        _launchAngle = Mathf.Clamp(_launchAngle, -60.0f, 60.0f);
        _arrow.transform.rotation = Quaternion.Euler(_launchAngle * Vector3.forward);
    }

    public void ResetLaunch()
    {
        ResetSphere();
        _sphere.ResetSphere();
        _arrow.SetActive(true);
        _hasLaunched = false;
    }
    public void ResetSphere()
    {
        _sphere.StopSphere();
        _sphere.ResetSphere();
    }
}
