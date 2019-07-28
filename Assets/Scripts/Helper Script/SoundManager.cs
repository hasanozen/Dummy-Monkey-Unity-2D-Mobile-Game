using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpClip, gameOverClip, coinTakeClip;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void JumpSoundFX()
    {
        soundFX.clip = jumpClip;
        soundFX.Play(); 
    }

    public void GameOverSoundFX()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void CoinTakeSoundFX()
    {
        soundFX.clip = coinTakeClip;
        soundFX.Play();
    }
} // class
