using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScreen : MonoBehaviour
{
    public RectTransform logoImage;
    public TextMeshProUGUI startGameText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShakeLogoAction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShakeLogoAction()
    {
        yield return ShowUpLogo();
        yield return ShakeLogo();
        DisappearLogo();
        yield return BlinkStartGameText();
    }

    IEnumerator ShowUpLogo()
    {
        logoImage.gameObject.SetActive(true);
        Vector3 startSize = new Vector3(0f, 0f, 0f);
        Vector3 endSize = new Vector3(1f, 1f, 1f);
        float t = 0f;
        while(t < 1f)
        {
            t = Mathf.Clamp01(t + Time.fixedDeltaTime);
            logoImage.localScale = Vector3.Lerp(startSize, endSize, t);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator ShakeLogo()
    {
        float t = 0f;
        Vector3 rot = new Vector3(0f, 0f, 0f);
        while (t < 1f)
        {
            t = Mathf.Clamp01(t + Time.fixedDeltaTime);
            rot.z = Mathf.Sin(t * 5f * Mathf.PI);
            logoImage.Rotate(rot);
            yield return new WaitForFixedUpdate();
        }
    }

    void DisappearLogo()
    {
        logoImage.gameObject.SetActive(false);
    }

    IEnumerator BlinkStartGameText()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            startGameText.gameObject.SetActive(!startGameText.gameObject.activeSelf);
        }
    }
}
