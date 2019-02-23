﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    [SerializeField]
    LegLine firstPlayerLeftLegLine;
    [SerializeField]
    LegLine firstPlayerRightLegLine;

    [SerializeField]
    LegLine secondPlayerLeftLegLine;
    [SerializeField]
    LegLine secondPlayerRightLegLine;

    [SerializeField]
    GameObject firstPlayer;
    [SerializeField]
    GameObject secondPlayer;

    [SerializeField]
    InputGui inputGui;

    private void Start()
    {
        StartCoroutine(WaitForInput());
    }


    private void SpawnPlayer(GameObject player)
    {
        player.SetActive(true);
    }

    private void HidePlayer(GameObject player)
    {
        player.SetActive(false);
    }

    IEnumerator WaitForInput()
    {
        bool firstPlayerReady = false;
        bool secondPlayerReady = false;
        bool ready = false;
        while (!ready) 
        { 
            if (firstPlayerLeftLegLine.SelectedKeyIndex == 0 && firstPlayerRightLegLine.SelectedKeyIndex == 0)
            {
                if (!firstPlayerReady)
                {
                    SpawnPlayer(firstPlayer);
                    firstPlayerReady = true;
                    inputGui.HideFirstPlayerText();
                }
            }
            else
            {
                if (firstPlayerReady)
                {
                    firstPlayerReady = false;
                    HidePlayer(firstPlayer);
                    inputGui.ShowFirstPlayerText();
                }
            }

            if (secondPlayerLeftLegLine.SelectedKeyIndex == 0 && secondPlayerRightLegLine.SelectedKeyIndex == 0)
            {
                if (!secondPlayerReady)
                {
                    SpawnPlayer(secondPlayer);
                    secondPlayerReady = true;
                    inputGui.HideSecondPlayerText();
                }
            }
            else
            {
                if (secondPlayerReady)
                {
                    secondPlayerReady = false;
                    HidePlayer(secondPlayer);
                    inputGui.ShowSecondPlayerText();

                }
            }

            if (firstPlayerReady && secondPlayerReady)
            {
                ready = true;
            }
            yield return null; 
        }
        StartMatch();
    }

    private void StartMatch()
    {
        inputGui.HideBoth();
    }
}
