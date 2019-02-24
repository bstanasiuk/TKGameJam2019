using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGuiInitializer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI firstPlayerScoreText;
    [SerializeField]
    TextMeshProUGUI secondPlayerScoreText;

    const string firstPlayerHash="player9";
    const string secondPlayerHash="player10";

    private void Start()
    {
        if (PlayerPrefs.HasKey(firstPlayerHash))
        {
            firstPlayerScoreText.text = PlayerPrefs.GetInt(firstPlayerHash).ToString();
        }
        else
        {
            firstPlayerScoreText.text = "0";
            PlayerPrefs.SetInt(firstPlayerHash,0);
        }

        if (PlayerPrefs.HasKey(secondPlayerHash))
        {
            secondPlayerScoreText.text = PlayerPrefs.GetInt(secondPlayerHash).ToString();
        }
        else
        {
            secondPlayerScoreText.text = "0";
            PlayerPrefs.SetInt(secondPlayerHash, 0);
        }
    }
}
