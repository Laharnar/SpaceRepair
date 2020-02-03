using UnityEngine;

public class PlaySoundOnTimer:MonoBehaviour {

    public float startPlaying = 30;
    public AudioSource src;
    public bool played = false;

    private void Awake()
    {
        src.PlayDelayed(startPlaying);
    }
    private void OnLevelWasLoaded(int level)
    {
        src.Stop();
        src.Play();
    }
}
