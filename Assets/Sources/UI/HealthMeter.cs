using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    public Image icon;
    public Sprite deathSprite;
    public Sprite lifeSprite;

    public Image fill;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        PlayerEvents.Instance.OnHealthChange.Add(UpdateFill);
        PlayerEvents.Instance.OnPlayerDied.Add(UpdateIcon);
        PlayerEvents.Instance.OnPlayerRespawned.Add(UpdateIcon);
    }

    void UpdateFill()
    {
        StartCoroutine(LerpFill(PlayerStates.Instance.Health));
    }

    void UpdateIcon()
    {
        if (PlayerStates.Instance.IsDead)
            icon.sprite = deathSprite;
        else
            icon.sprite = lifeSprite;
    }

    IEnumerator LerpFill(float targetFill)
    {
        while (fill.fillAmount != targetFill)
        {
            fill.fillAmount = Mathf.Lerp(fill.fillAmount, PlayerStates.Instance.Health, Time.deltaTime);
            fill.color = gradient.Evaluate(fill.fillAmount);
            yield return null;
        }
    }
}
