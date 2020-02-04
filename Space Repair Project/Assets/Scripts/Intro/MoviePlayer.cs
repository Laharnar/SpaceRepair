using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MoviePlayer : MonoBehaviour
{
    public bool testMode = false;
    public bool externallyTriggerVideo = false;
    public bool playOnStart = false;
    public VideoPlayer movie;
    public bool disableOnDone=false;
    public float vidLen=45;
    public bool disableOnReload = false;
    public bool skipOnEsc = false;
    public PlaySoundOnTimer sound;
    public GameObject skipText = null;

    private void Start()
    {
        if (sound == null) sound = GetComponent<PlaySoundOnTimer>();
        gameObject.GetComponent<VideoPlayer>().targetCamera = Camera.main;
        if (playOnStart)
        {
            externallyTriggerVideo = true;
        }
    }

    void Update()
    {
        
        if (skipOnEsc && Input.GetKeyDown(KeyCode.Escape))
        {
            movie.Stop();
            if (sound) sound.PlaySoundFx();
            skipText.SetActive(false);
        }
        if (disableOnDone && Time.timeSinceLevelLoad > vidLen)
        {
            //movie.targetCamera = null;
            if(!movie.isPlaying)
                movie.Stop();
                skipText.SetActive(false);
        }
        if (testMode && Input.GetKeyDown(KeyCode.Space))
        {
            if (movie.isPlaying)
            {
                movie.Stop();
                skipText.SetActive(false);

            }
            else
            {
                movie.Play();
            }
        }
        if (externallyTriggerVideo)
        {
            externallyTriggerVideo = false;
            if (movie.isPlaying)
            {
                movie.Stop();
                skipText.SetActive(false);

            }
            else
            {
                //Debug.Log("play");
                movie.Play();
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        //movie.targetCamera = Camera.main;

        if (disableOnReload)
        {
            playOnStart = false;
            //movie.targetCamera = null;
            externallyTriggerVideo = false;
            if (sound) sound.Stop(); skipText.SetActive(false);
            
        }
    }
}
