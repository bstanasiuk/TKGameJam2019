using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SlomoHandler slomoHandler;
    private int health=3;
    private bool hasArmor;

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

    public void AddArmor()
    {
        hasArmor = true;
    }

    private void Hit()
    {
        if (slomoHandler && !hasArmor) slomoHandler.StartSlomo();
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
