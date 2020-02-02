using UnityEngine;

public class SoundLibrary:MonoBehaviour {

    public static SoundLibrary lib;

    public SoundClipData[] clips;

    private void Awake()
    {
        lib = this;
    }

    internal AudioClip GetSoundClip(SoundPlay sound)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].soundId == sound)
            {
                return clips[i].clip;
            }
        }
        Debug.Log("Clip not found.");
        return null;
    }
}
