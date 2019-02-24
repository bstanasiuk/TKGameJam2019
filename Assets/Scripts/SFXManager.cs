using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip [] beatAudioClip;

    private AudioSource audioSource;
    // Start is called before the first frame update

    private int iterator = 0;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            GameObject temp = new GameObject("audioSource");
            audioSource = temp.AddComponent<AudioSource>();
            audioSource.clip = beatAudioClip[iterator];
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
            Destroy(temp, beatAudioClip[iterator].length + 0.1f);
            iterator++;
            if(iterator == beatAudioClip.Length)
            {
                iterator = 0;
            }
            //beatAudioClip.
        }
    }
}
