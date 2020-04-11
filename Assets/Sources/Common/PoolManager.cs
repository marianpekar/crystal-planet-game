using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    GameObject pool;

    [SerializeField]
    Transform spawnPivotPoint;

    [SerializeField]
    float offsetXLimit = 100f;

    [SerializeField]
    float offsetZLimit = 35f;

    [SerializeField] 
    int objectsLayerIndex;

    private Transform[] transforms;

    void Start()
    {
        transforms = pool.GetComponentsInChildren<Transform>();

        foreach (Transform transform in transforms)
        {
            if(transform.gameObject.layer == objectsLayerIndex)
                transform.gameObject.GetComponent<MovableObjectController>().PoolManager = this;

            Respawn(transform);
        }
    }

    public void Respawn(Transform transform)
    {
        transform.position = new Vector3(spawnPivotPoint.position.x + offsetXLimit * Random.Range(-1f, 1f), 
                                           transform.position.y,
                                         spawnPivotPoint.position.z + offsetZLimit * Random.Range(0, 1f));

        transform.Rotate(0f, Random.Range(0f, 259f), 0f, Space.World);
    }
}
