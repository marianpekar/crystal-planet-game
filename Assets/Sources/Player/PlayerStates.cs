﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerStates
{
    // Movement
    public float FlightSpeed { get; } = 80f;
    public float SteeringSpeed { get; } = 7f;
    public Vector3 SteeringTiltAngle { get; } = new Vector3(0, 16f, 22f);
    public float SteeringTiltSpeed { get; } = 8f;
    public float ShakeStrength { get; } = 0.1f;

    // Health & Damage
    public bool IsDead { get; set; } = false;
    public int Health { get; set; } = 100;
    public int MaxHealth { get; } = 100;
    public int MinDamage { get; set; } = 25;
    public int MaxDamage { get; set; } = 50;


    private static PlayerStates instance;
    public static PlayerStates Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerStates();
            }

            return instance;
        }
    }
}
