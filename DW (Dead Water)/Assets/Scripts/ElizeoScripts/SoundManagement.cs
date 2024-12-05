using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip battleMusic;
    public AudioClip travelMusic;
    public AudioClip attackSound;
    public AudioClip victorySound;
    public AudioClip defeatSound;
}
