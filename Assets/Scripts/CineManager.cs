using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmvStandard;
    [SerializeField] private CinemachineVirtualCamera cmvClose;
    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnHit);
    }

    // Update is called once per frame
    void OnHit(PlayerDeadStruct pos)
    {
        cmvStandard.enabled = false;
        cmvClose.enabled = true;
    }
}
