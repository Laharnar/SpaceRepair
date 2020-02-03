using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    public float playInDistToPlayer = 10;
    AudioSource a;
    public SoundPlay playSound;
    public bool activateOnStart = false;

    private void Start()
    {
        a = GetComponent<AudioSource>();
        if (activateOnStart)
        {
            PlaySoundFx(playSound);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
            PlaySoundFx(playSound);
        if (Player.playerGo != null && !Player.PlayerSc.won)
        {
            a.volume = 1 - (Mathf.Clamp(Vector2.Distance(transform.position, Player.playerGo.transform.position), 0, playInDistToPlayer) / playInDistToPlayer);
            a.volume *= a.volume/2;
        }
        else
        {
            a.volume = 0;
        }
    }

    public void PlaySoundFx()
    {
        PlaySoundFx(playSound);
    }

    public void PlaySoundFx(SoundPlay sound)
    {
        a.clip = SoundLibrary.lib.GetSoundClip(sound);
        //Debug.Log("Playing "+a.clip );
        a.Play();
    }
}
