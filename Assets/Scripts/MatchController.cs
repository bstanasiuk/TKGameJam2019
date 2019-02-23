using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    [SerializeField]
    LegLine firstPlayerLeftLeg;
    [SerializeField]
    LegLine firstPlayerRightLeg;

    [SerializeField]
    LegLine secondPlayerLeftLeg;
    [SerializeField]
    LegLine secondPlayerRightLeg;

    [SerializeField]
    GameObject firstPlayer;
    [SerializeField]
    GameObject secondPlayer;

    private void Start()
    {
        StartCoroutine(WaitForInput());
    }


    private void SpawnPlayer(GameObject player)
    {
        player.SetActive(true);
    }

    IEnumerator WaitForInput()
    {
        bool firstPlayerReady = false;
        bool secondPlayerReady = false;
        bool ready = false;
        while (!ready) 
        { 
            if (!firstPlayerReady && (firstPlayerLeftLeg.SelectedKeyIndex == 0 && firstPlayerRightLeg.SelectedKeyIndex == 0))
            {
                SpawnPlayer(firstPlayer);
                firstPlayerReady = true;
            }

            if (!secondPlayerReady && (secondPlayerLeftLeg.SelectedKeyIndex == 0 && secondPlayerRightLeg.SelectedKeyIndex == 0))
            {
                SpawnPlayer(secondPlayer);
                secondPlayerReady = true;
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

    }
}
