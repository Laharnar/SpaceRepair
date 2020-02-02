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

    private void Start()
    {
        gameObject.GetComponent<VideoPlayer>().targetCamera = Camera.main;
        if (playOnStart)
        {
            externallyTriggerVideo = true;
        }
    }

    void Update()
    {
        if (disableOnDone && Time.time > vidLen)
        {
            movie.targetCamera = null;
        }
        if (testMode && Input.GetKeyDown(KeyCode.Space))
        {
            if (movie.isPlaying)
            {
                movie.Stop();
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
            }
            else
            {
                Debug.Log("play");
                movie.Play();
            }
        }
    }
}
