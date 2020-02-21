using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerStates
{
    // Movement
    public float FlightSpeed { get; } = 0.1f;
    public float SteeringSpeed { get; } = 0.1f;
    public Vector3 SteeringTiltAngle { get; } = new Vector3(0, 12f, 22f);
    public float SteeringTiltSpeed { get; } = 15f;


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
