using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Background,
    Grab,
    Sell
}
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource loopAudioSource;
    [SerializeField] private AudioSource singleAudioSource;
    [SerializeField] private AudioClip grabClip, sellClip, backgroundClip;

    private static SoundController instance;
    public static SoundController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake() 
    {
        // Singleton setup
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
    }
    private void Start() 
    {
        PlayLoopSound(SoundType.Background);
    }

    public void PlaySingleSound(SoundType soundType)
    {
        if (singleAudioSource != null)
        {
            AudioClip clip = null;
            if (soundType == SoundType.Grab)
            {
                clip = grabClip;
            }
            else if (soundType == SoundType.Sell)
            {
                clip = sellClip;
            }
            singleAudioSource.clip = clip;
            singleAudioSource.Play();
        }
    }
    public void PlayLoopSound(SoundType soundType)
    {
        if (loopAudioSource != null)
        {
            AudioClip clip = null;
            if (soundType == SoundType.Background)
            {
                clip = backgroundClip;
            }

            loopAudioSource.clip = clip;
            loopAudioSource.Play();
        }
    }
}
