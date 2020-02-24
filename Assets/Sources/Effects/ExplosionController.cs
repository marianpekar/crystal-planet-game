using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;

    [SerializeField]
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        PlayerEvents.Instance.OnCrystalCollision.Add(Explode);
    }

    // Update is called once per frame
    void Explode()
    {
        particleSystem.Play();
        audioSource.Play();
    }
}
