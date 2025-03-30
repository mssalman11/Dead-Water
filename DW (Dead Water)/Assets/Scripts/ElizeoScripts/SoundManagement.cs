using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource traverseSource;
    public AudioSource battleSource;
    public AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip battleMusic;
    public AudioClip travelMusic;
    public AudioClip attackSound;
    public AudioClip victorySound;
    public AudioClip defeatSound;
    public AudioClip healSound;
    public AudioClip invalidSound;
    public AudioClip itemSound;
    public AudioClip goldSound;

    public void Start()
    {
        traverseSource.clip = travelMusic;
        battleSource.clip = battleMusic;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
