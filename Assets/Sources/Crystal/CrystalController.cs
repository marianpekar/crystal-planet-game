using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    public CrystalManager CrystalManager { get; set; }

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
        CrystalManager.RespawnCrystal(transform);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Respawn"))
        {
            Respawn();
        }
    }
}
