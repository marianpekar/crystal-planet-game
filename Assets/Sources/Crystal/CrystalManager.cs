using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [SerializeField]
    GameObject crystalPool;

    [SerializeField]
    Transform crystalSpawnPivot;

    private Transform[] crystals;

    void Start()
    {
        crystals = crystalPool.GetComponentsInChildren<Transform>();

        foreach(Transform crystal in crystals)
        {
            crystal.position = crystalSpawnPivot.position;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
