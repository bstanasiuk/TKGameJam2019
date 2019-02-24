using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crunch : MonoBehaviour
{
    public static Crunch Instance;

    public AudioClip[] crunchSounds;
    public AudioSource punchAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (Crunch.Instance == null)
        {
            Crunch.Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayCrunch()
    {
        punchAudioSource.clip = GetRandomAudioClip();
        if (!punchAudioSource.isPlaying)
        {
            punchAudioSource.Play();
        }
    }

    AudioClip GetRandomAudioClip()
    {
        int r = Random.Range(0, crunchSounds.Length);
        return crunchSounds[r];
    }
}
