using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectButton : MonoBehaviour
{
    [SerializeField] private GameObject effectOn;
    [SerializeField] private GameObject effectOff;

    private void Start()
    {
        if (!SoundManager.effectSoundIsActive)
        {
            effectOn.SetActive(false);
            effectOff.SetActive(true);
        }
        else
        {
            effectOn.SetActive(true);
            effectOff.SetActive(false);
        }
    }

    public void TurnEffectOn()
    {
        effectOn.SetActive(true);
        effectOff.SetActive(false);

        SoundManager.Instance.SetValueEffectSound();
        SoundManager.Instance.PlayEffect();
    }
    
    public void TurnEffectOff()
    {
        effectOn.SetActive(false);
        effectOff.SetActive(true);

        SoundManager.Instance.SetValueEffectSound();
    }
}
