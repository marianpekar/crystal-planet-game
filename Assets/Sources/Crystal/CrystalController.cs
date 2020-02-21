using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    private CrystalManager crystalManager;

    void Update()
    {
        transform.Translate(-Vector3.forward * PlayerStates.Instance.FlightSpeed * Time.deltaTime, Space.World);
    }

    public void SetCrystalManager(CrystalManager crystalManager)
    {
        this.crystalManager = crystalManager;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Respawn"))
            crystalManager.RespawnCrystal(transform);
    }
}
