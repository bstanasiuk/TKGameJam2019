using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private int _winScore;
    [SerializeField] private RectTransform _winPanel;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private ResetManager _resetManager;

    private void Update()
    {
        var firstPlayerKey = "player9";
        var secondPlayerKey = "player10";
        var firstPlayerScore = 0;
        var secondPlayerScore = 0;
        if (PlayerPrefs.HasKey(firstPlayerKey))
        {
            firstPlayerScore = PlayerPrefs.GetInt(firstPlayerKey);

        }
        if (PlayerPrefs.HasKey(firstPlayerKey))
        {
            secondPlayerScore = PlayerPrefs.GetInt(secondPlayerKey);
        }
        if (firstPlayerScore >= _winScore) 
            FirstPlayerWins();
        if (secondPlayerScore >= _winScore)
            SecondPlayerWins();
    }

    private void FirstPlayerWins()
    {
        _resetManager.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(true);
        _winText.text = "BLUE WINS!";
        _winText.color = Color.blue;
    }

    private void SecondPlayerWins()
    {
        _resetManager.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(true);
        _winText.text = "RED WINS!";
        _winText.color = Color.red;
    }
}
