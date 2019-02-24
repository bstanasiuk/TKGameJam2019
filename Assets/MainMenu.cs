using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToMatchScene();
        }
    }

    void GoToMatchScene()
    {
        SceneManager.LoadScene("FinalRondaar");
    }
}
