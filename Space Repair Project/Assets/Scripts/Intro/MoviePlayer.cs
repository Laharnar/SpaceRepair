using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.Video;

public class MoviePlayer : MonoBehaviour
{
    public bool testMode = false;
    public bool externallyTriggerVideo = false;
    public bool playOnStart = false;
    public string videoName;
    public VideoPlayer videoPlayer;
    //public RawImage videoImage;
    public bool disableOnDone=false;
    public float vidLen=45;
    public bool disableOnReload = false;
    public bool skipOnEsc = false;
    public PlaySoundOnTimer sound;
    public GameObject skipText = null;

    public void PlayStreamingClip(string videoFile, bool looping = true)
    {
        // videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = Application.streamingAssetsPath + "/" + videoFile;
        //videoPlayer.isLooping = looping;
        StartCoroutine(PlayVideo());
    }



    private IEnumerator PlayVideo()
    {
        // We must set the audio before calling Prepare, otherwise it won't play the audio

        var audioSource = videoPlayer.GetComponent<AudioSource>();
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Wait until ready

        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return null;


        videoPlayer.Play();

        //videoImage.texture = videoPlayer.texture;
        while (videoPlayer.isPlaying)

            yield return null;
        //onVideoFinished.Invoke(this);

    }

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
        
        if (skipOnEsc && Input.GetKeyDown(KeyCode.Escape) && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            if (sound) sound.PlaySoundFx();
            skipText.SetActive(false);
        }
        if (disableOnDone && Time.timeSinceLevelLoad > vidLen)
        {
            //movie.targetCamera = null;
            if(!videoPlayer.isPlaying)
                videoPlayer.Stop();
                skipText.SetActive(false);
        }
        if (testMode && Input.GetKeyDown(KeyCode.Space))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
                skipText.SetActive(false);

            }
            else
            {
                videoPlayer.Play();
            }
        }
        if (externallyTriggerVideo)
        {
            externallyTriggerVideo = false;
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
                skipText.SetActive(false);

            }
            else
            {
                PlayStreamingClip(videoName, videoPlayer.isLooping);
                //Debug.Log("play");
                //videoPlayer.Play();
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
