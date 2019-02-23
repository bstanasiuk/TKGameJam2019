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
        }
    }
}
