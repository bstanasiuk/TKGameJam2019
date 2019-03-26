using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleManager : MonoBehaviour
{
    void Start()
    {
        EventManager.Instance.PlayerHit.AddListener(OnHit);
    }

    void OnHit(PlayerHitStruct playerHitStruct)
    {
        transform.position = playerHitStruct.position;  
        transform.rotation = Quaternion.LookRotation(playerHitStruct.rotation);
        transform.parent = playerHitStruct.gameObject.transform;
       
        GetComponent<ParticleSystem>().Play();
    }


}
