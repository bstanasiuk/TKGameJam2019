using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputGui : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI firstPlayerText;
    [SerializeField]
    TextMeshProUGUI secondPlayerText;


    public void HideBoth()
    {
        HideFirstPlayerText();
        HideSecondPlayerText();
    }

    public void HideFirstPlayerText()
    {
        firstPlayerText.gameObject.SetActive(false);
    }

    public void HideSecondPlayerText()
    {
        secondPlayerText.gameObject.SetActive(false);
    }

    public void ShowFirstPlayerText()
    {
        firstPlayerText.gameObject.SetActive(true);
    }

    public void ShowSecondPlayerText()
    {
        secondPlayerText.gameObject.SetActive(true);
    }
}
