using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffectController : MonoBehaviour
{
    [SerializeField] 
    private AudioSource powerUpSound;

    void Start()
    {
        PlayerEvents.Instance.OnHealthRestored.Add(PlayPowerUpSound);
    }

    // Update is called once per frame
    void PlayPowerUpSound()
    {
        powerUpSound.Play();
    }
}
