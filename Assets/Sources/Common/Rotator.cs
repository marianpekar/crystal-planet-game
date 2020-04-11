using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] 
    float rotationSpeed = 3f;

    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
    }
}
