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
    public AudioClip ding;
    public AudioClip punk;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void OnEnable()
    {
        EventManager.StudentDeath += EventManager_StudentDeath;
        EventManager.StudentEscape += EventManager_StudentEscape;
    }
    public void OnDisable()
    {
        EventManager.StudentDeath -= EventManager_StudentDeath;
        EventManager.StudentEscape -= EventManager_StudentEscape;
    }

    private void EventManager_StudentEscape()
    {
        PlaySFX(ding);
    }

    private void EventManager_StudentDeath()
    {
        PlaySFX(death);
    }
}
