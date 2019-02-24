using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shield")) return;
        if (gameObject.layer.Equals(other.gameObject.layer)) return;
        var playerHealth = other.transform.GetComponentInParent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.Health--;
            if(playerHealth.Health == -1)
            {
                PlayerHitStruct playerHitStruct = new PlayerHitStruct();
                playerHitStruct.position = other.contacts[0].point;
                playerHitStruct.rotation = other.contacts[0].normal;
                playerHitStruct.gameObject = other.collider.gameObject;
                EventManager.Instance.PlayerHit.Invoke(playerHitStruct);
            }
        }
    }
}
