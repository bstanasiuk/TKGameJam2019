using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmvStandard;
    [SerializeField] private CinemachineVirtualCamera cmvClose;
    [SerializeField] private CinemachineTargetGroup cmTargetGroup;
    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnHit);
        EventManager.Instance.PlayerReady.AddListener(OnPlayerReady);
        EventManager.Instance.PlayerUnready.AddListener(OnPlayerReady);
    }

    // Update is called once per frame
    void OnHit(PlayerDeadStruct pos)
    {
        cmvStandard.enabled = false;
        cmvClose.enabled = true;
    }

    void OnPlayerReady(int number)
    {
        cmTargetGroup.m_Targets[number].weight = 1.0f;
    }

    void OnPlayerUnready(int number)
    {
        cmTargetGroup.m_Targets[number].weight = 0.0f;
    }
}
