using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [SerializeField]
    GameObject crystalPool;

    [SerializeField]
    Transform crystalSpawnPivot;

    [SerializeField]
    float offsetXLimit = 100f;

    [SerializeField]
    float offsetZLimit = 35f;

    private Transform[] crystals;

    void Start()
    {
        crystals = crystalPool.GetComponentsInChildren<Transform>();

        foreach (Transform crystal in crystals)
        {
            if(crystal.CompareTag("Crystal"))
                crystal.gameObject.GetComponent<CrystalController>().CrystalManager = this;

            RespawnCrystal(crystal);
        }
    }

    public void RespawnCrystal(Transform crystal)
    {
        crystal.position = new Vector3(crystalSpawnPivot.position.x + offsetXLimit * Random.Range(-1f, 1f),
                                       crystalSpawnPivot.position.y,
                                       crystalSpawnPivot.position.z + offsetZLimit * Random.Range(0, 1f));

        crystal.Rotate(0f, Random.Range(0f, 259f), 0f, Space.World);
    }
}
