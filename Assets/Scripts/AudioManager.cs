using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource SFXSource;
    [Header("Clips")]
    public AudioClip death;
    public AudioClip riff_1;
    public AudioClip riff_2;
    public AudioClip whistle;
    public AudioClip punk;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
