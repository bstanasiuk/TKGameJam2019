using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI myScoreText;

    const string hashKeyPrefix = "player";
    string hashKey;


    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnDead);
        hashKey = hashKeyPrefix + gameObject.layer.ToString();
        if(PlayerPrefs.HasKey(hashKey))
        {
            myScoreText.text = PlayerPrefs.GetInt(hashKey).ToString();

        }
        else
        {
            PlayerPrefs.SetInt(hashKey, 0);
            myScoreText.text = "0";
        }
    }

   

    // Update is called once per frame
    void OnDead(PlayerDeadStruct pds)
    {
        if (pds.layer != gameObject.layer)
        {
            PlayerPrefs.SetInt(hashKey, PlayerPrefs.GetInt(hashKey) + 1);
            myScoreText.text = PlayerPrefs.GetInt(hashKey).ToString();
        }

    }
}
