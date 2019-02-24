using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    [SerializeField] private float timeBeforeRestart = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnHit);
    }

    // Update is called once per frame
    void OnHit(Vector3 pos)
    {
        StartCoroutine(OnPlaerDead());
    }

    IEnumerator OnPlaerDead()
    {
        yield return new WaitForSeconds(timeBeforeRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
