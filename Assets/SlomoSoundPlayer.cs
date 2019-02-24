using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlomoSoundPlayer : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnDead);
    }

    private void OnDead(PlayerDeadStruct psd)
    {
        GetComponent<AudioSource>().Play();
    }
}
