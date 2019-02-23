using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        var playerHealth = other.transform.GetComponentInParent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.Health--;
        }
    }
}
