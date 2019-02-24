using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorParticleDestroy : MonoBehaviour
{
    public static ArmorParticleDestroy Instance;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        if (ArmorParticleDestroy.Instance == null)
        {
            ArmorParticleDestroy.Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(Vector3 pos)
    {
        ParticleSystem newps = GameObject.Instantiate(ps, pos, Quaternion.identity);
        newps.Play();
    }
}
