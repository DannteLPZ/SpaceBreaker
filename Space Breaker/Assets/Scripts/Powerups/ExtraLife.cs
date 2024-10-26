using UnityEngine;

public class ExtraLife : PowerUp
{
    protected override void StartPowerUp(Collider2D collision)
    {
        collision.TryGetComponent(out PlayerLives lives);
        if (lives != null) lives.AddLife();
        Destroy(gameObject);
    }
}