using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    #region singleton
    private static MusicPlayer instance;
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
