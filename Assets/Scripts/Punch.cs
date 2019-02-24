using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public static Punch Instance;

    public AudioClip[] punchSounds;
    public AudioSource punchAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if(Punch.Instance == null)
        {
            Punch.Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPunch()
    {
        punchAudioSource.clip = GetRandomAudioClip();
        if (!punchAudioSource.isPlaying)
        {
            punchAudioSource.Play();
        }
    }

    AudioClip GetRandomAudioClip()
    {
        int r = Random.Range(0, punchSounds.Length);
        return punchSounds[r];
    }
}
