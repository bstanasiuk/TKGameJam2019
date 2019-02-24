using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.Rendering.PostProcessing;

public class ResetManager : MonoBehaviour
{
    [SerializeField] private float timeBeforeRestart = 3.0f;
    // Start is called before the first frame update

    PostProcessVolume volume;

    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnHit);
        volume = GameObject.Find("Main Camera").gameObject.GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void OnHit(PlayerDeadStruct pos)
    {
        SlomoHandler.Instance.StartSlomo();
        StartCoroutine(OnPlaerDead());
        StartCoroutine(Desaturate());
    }

    IEnumerator OnPlaerDead()
    {
        yield return new WaitForSecondsRealtime(timeBeforeRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    IEnumerator Desaturate()
    {
        ColorGrading colorGradingLayer = null;
        volume.profile.TryGetSettings(out colorGradingLayer);
        colorGradingLayer.saturation.value = -100.0f;
        yield return new WaitForSecondsRealtime(timeBeforeRestart * 2.0f / 3.0f);
        yield return new WaitForSecondsRealtime(timeBeforeRestart * 1.0f / 3.0f);
    }
}
