using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/Power up/Trigger")]
public class TriggerPowerUp : PowerUpSO
{
    public GameEvent _onPoweredUp;

    public override void ActivatePowerup() => _onPoweredUp.Invoke();
}

public abstract class PowerUpSO : ScriptableObject
{
    public abstract void ActivatePowerup();
}
