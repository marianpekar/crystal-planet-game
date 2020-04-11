using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerEvents
{
    public List<Action> OnHealthChange { get; set; } = new List<Action>();
    public List<Action> OnPlayerDied { get; set; } = new List<Action>();
    public List<Action> OnPlayerRespawned { get; set; } = new List<Action>();
    public List<Action> OnCrystalCollision { get; set; } = new List<Action>();
    public List<Action> OnHealthRestored { get; set; } = new List<Action>();

    public void HealthChanged() 
    {
        InvokeActions(OnHealthChange);
    }

    public void PlayerDied()
    {
        InvokeActions(OnPlayerDied);
    }

    public void PlayerRespawned()
    {
        InvokeActions(OnPlayerRespawned);
    }

    public void CrystalCollision()
    {
        InvokeActions(OnCrystalCollision);
    }

    public void HealthRestored()
    {
        InvokeActions(OnHealthRestored);
    }

    private void InvokeActions(List<Action> actions)
    {
        foreach (var action in actions)
        {
            action.Invoke();
        }
    }

    private static PlayerEvents instance;
    public static PlayerEvents Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerEvents();
            }

            return instance;
        }
    }
}
