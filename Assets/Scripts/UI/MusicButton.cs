using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private GameObject musicOn;
    [SerializeField] private GameObject musicOff;

    private void Start()
    {
        if (SoundManager.Instance.musicSoundIsMuted())
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }
        
    public void TurnMusicOn()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        SoundManager.Instance.PlayEffect();
        SoundManager.Instance.ToggleMusic();
    }

    public void TurnMusicOff()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        SoundManager.Instance.PlayEffect();
        SoundManager.Instance.ToggleMusic();
    }
}
