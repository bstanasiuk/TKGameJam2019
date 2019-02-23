﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlomoHandler : MonoBehaviour
{
    [SerializeField]
    float slomoTime=2f;

    bool isSlomo;

    public void StartSlomo()
    {

        if (!isSlomo)
        {
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            isSlomo = true;
            StartCoroutine(Slomo());

        }
       

    }

    IEnumerator Slomo()
    {
        while(Time.timeScale<1)
        {
            Time.timeScale += Time.unscaledDeltaTime * (1f / slomoTime);
            yield return null;
        }
        Time.timeScale = 1;
        Time.fixedDeltaTime =  Time.timeScale * 0.02f;
        isSlomo = false;
    }
}