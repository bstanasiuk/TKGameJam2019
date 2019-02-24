using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SlomoHandler slomoHandler;
    private int health=3;
    public GameObject Armor { get; set; }

    private bool isInvincible=false;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (!isInvincible)
            {
                health = value;
                Hit();
                isInvincible = true;
                StartCoroutine(InvincibleTime());
            }
        }
    }

    private void Hit()
    {
        if (Armor)
        {
            Destroy(Armor);
            Armor = null;
            return;
        }
        if(health<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        EventManager.Instance.PlayerDead.Invoke(Vector3.zero);
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(.25f);
        isInvincible = false;
    }
}
