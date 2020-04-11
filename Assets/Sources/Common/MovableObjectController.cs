using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectController : MonoBehaviour
{
    public PoolManager PoolManager { get; set; }

    private bool shouldMove = true;

    void Start()
    {
        PlayerEvents.Instance.OnPlayerDied.Add(StopMovement);
        PlayerEvents.Instance.OnPlayerRespawned.Add(ResetAll);
    }

    void Update()
    {
        if(shouldMove)
            transform.Translate(-Vector3.forward * PlayerStates.Instance.FlightSpeed * Time.deltaTime, Space.World);
    }

    private void StopMovement()
    {
        shouldMove = false;
    }

    private void ResetAll()
    {
        Respawn();
        shouldMove = true;
    }

    public void Respawn()
    {
        PoolManager.Respawn(transform);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Respawn"))
        {
            Respawn();
        }
    }
}
