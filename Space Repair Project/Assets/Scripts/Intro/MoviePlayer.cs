using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MoviePlayer : MonoBehaviour
{
    public bool testMode = false;
    public bool externallyTriggerVideo = false;
    public bool playOnStart = false;
    public VideoPlayer movie;

    private void Start()
    {
        if (playOnStart)
        {
            externallyTriggerVideo = true;
        }
    }

    void Update()
    {
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
                movie.Play();
            }
        }
    }
}
