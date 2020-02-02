using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{

    AudioSource a;
    public SoundPlay playSound;

    private void Start()
    {
        a = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
            PlaySoundFx(playSound);
    }

    public void PlaySoundFx(SoundPlay sound)
    {
        a.clip = SoundLibrary.lib.GetSoundClip(sound);
        Debug.Log("Playing "+a.clip );
        a.Play();
    }
}
