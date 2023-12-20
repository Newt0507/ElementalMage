using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource effectsSoundSource, musicSoundSource, vfxSoundSource;

    public static bool effectSoundIsActive;

    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitSound;

    private bool isMoving;
    private bool isAttacking;
    private bool isHitting;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        effectSoundIsActive = true;
        SetActiveVFXSound(false);
    }

    private void Update()
    { 
        if (effectSoundIsActive)
        {
            CheckBattleSound(vfxSoundSource, moveSound, isMoving);
            CheckBattleSound(vfxSoundSource, attackSound, isAttacking);
            CheckHitSound();
        }
    }

    private void CheckBattleSound(AudioSource source, AudioClip clip, bool isDoing)
    {
        if (isDoing && !source.isPlaying)
        {
            source.clip = clip;
            source.Play();
        }
        else if (!isDoing && source.clip == clip && source.isPlaying)
        {
            source.Stop();
        }
    }

    private void CheckHitSound()
    {
        if (isHitting)
        {
            vfxSoundSource.clip = hitSound;
            vfxSoundSource.Play();
            isHitting = false;
        }
    }

    public void SetMovingSound(bool moving)
    {
        isMoving = moving;
    }

    public void SetAttackingSound(bool attacking)
    {
        isAttacking = attacking;
    }

    public void SetHittingSound()
    {
        isHitting = true;
    }

    public void SetValueEffectSound()
    {
        effectSoundIsActive = !effectSoundIsActive;
    }

    public void PlayEffect()
    {
        if (effectSoundIsActive)
            effectsSoundSource.PlayOneShot(effectsSoundSource.clip);
    }
        
    public void PlayMusic(AudioClip musicClip)
    {
        musicSoundSource.clip = musicClip;
        if (!musicSoundSource.isPlaying)
        {
            musicSoundSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicSoundSource.mute = !musicSoundSource.mute;
    }

    public bool musicSoundIsMuted()
    {
        return musicSoundSource.mute;
    }

    public void ToggleVFX()
    {
        vfxSoundSource.mute = !vfxSoundSource.mute;
    }

    public void SetActiveVFXSound(bool status)
    {
        vfxSoundSource.gameObject.SetActive(status);
    }
}
