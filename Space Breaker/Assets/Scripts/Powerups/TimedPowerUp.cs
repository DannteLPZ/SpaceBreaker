using UnityEngine;

[CreateAssetMenu(fileName = "Timed Powerup", menuName = "Scriptable Objects/Power up/Timed")]
public class TimedPowerUp : PowerUpSO
{
    public FloatEvent _onPoweredUp;
    public float _powerDuration;

    public override void ActivatePowerup() => _onPoweredUp.Invoke(_powerDuration);
}
