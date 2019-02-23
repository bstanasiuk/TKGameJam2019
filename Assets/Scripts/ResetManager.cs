using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnHit);
    }

    // Update is called once per frame
    void OnHit(Vector3 pos)
    {
        
    }
}
