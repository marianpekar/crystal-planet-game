using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerManager
{
    public void TakeDamage()
    {
        PlayerStates.Instance.Health -= Random.Range(PlayerStates.Instance.MinDamage, PlayerStates.Instance.MaxDamage);
        if (PlayerStates.Instance.Health > 0)
        {
            PlayerEvents.Instance.HealthChanged();
        }
        else
        {
            PlayerStates.Instance.Health = 0;
            PlayerStates.Instance.IsDead = true;
            PlayerEvents.Instance.HealthChanged();
            PlayerEvents.Instance.PlayerDied();
        }
    }

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }

            return instance;
        }
    }
}
