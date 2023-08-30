using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    private static bool initialized = false;
    private static AudioSource audioSource;


    public static bool IsInitialized { get { return initialized; } }

    public static void Initialize(AudioSource _audioSource)
    {
        audioSource = _audioSource;
        initialized = true;
    }

    public static void Play(AudioClipName audioClipName)
    {
        AudioClip audioClip = null;

        switch (audioClipName) 
        {
            case AudioClipName.BallHitPaddle:
                audioClip = Resources.Load<AudioClip>("Sounds/boing");
                break;
            case AudioClipName.DestroyBrick:
                audioClip = Resources.Load<AudioClip>("Sounds/coin");
                break;
            case AudioClipName.BallLose:
                audioClip = Resources.Load<AudioClip>("Sounds/ballLose");
                break;
            case AudioClipName.YouWin:
                audioClip = Resources.Load<AudioClip>("Sounds/youWin");
                break;
            case AudioClipName.GameOver:
                audioClip = Resources.Load<AudioClip>("Sounds/gameOver");
                break;
        }

        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
