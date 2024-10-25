using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp Manager", menuName = "Scriptable Objects/PowerUp Manager")]
public class PowerUpManager : ScriptableObject
{
    public List<GameObject> PowerUps = new();
    [Range(1.0f, 100.0f)]
    public int Chance; // Percentage for acquiring any powerup

    public GameObject ChancePowerUp()
    {
        int getChance = Random.Range(1, 101);
        if (getChance > 100 - Chance)
        {
            int index = Random.Range(0, PowerUps.Count);
            return PowerUps[index];
        }
        else
            return null;
    }
}
