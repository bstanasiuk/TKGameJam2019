using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterGui : MonoBehaviour
{
    [SerializeField]
    MatchController matchController;
    [SerializeField]
    TextMeshProUGUI counterText;
    [SerializeField]
    Vector3 increasedSize;

    Vector3 initSize;

    float timeBetweenTicks = .4f;

    // Start is called before the first frame update
    void Start()
    {
        initSize = counterText.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCounter()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        int tick = 3;
        float timer = timeBetweenTicks;
        counterText.text = tick.ToString();
        while(tick>0)
        {

            counterText.transform.localScale = Vector3.Lerp(initSize, increasedSize, timer / timeBetweenTicks);
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                timer = timeBetweenTicks;
                tick--;
                if (tick!= 0)
                    counterText.text = tick.ToString();
            }
            yield return null;
        }

        timer = timeBetweenTicks;
        counterText.text = "FIGHT!";
        counterText.transform.localScale = increasedSize;
        while (timer>0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        matchController.Ready = true;
        counterText.text = "";

    }

    public void InterfereCounter()
    {
        StopAllCoroutines();
        counterText.text = "";
    }
}
