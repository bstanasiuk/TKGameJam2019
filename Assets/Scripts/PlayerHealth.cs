using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SlomoHandler slomoHandler;
    [SerializeField] private int health=3;
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


    private void Start()
    {
        EventManager.Instance.PlayerDead.AddListener(OnDead);
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
        PlayerDeadStruct playerDeadStruct = new PlayerDeadStruct();
        playerDeadStruct.layer = gameObject.layer;
        EventManager.Instance.PlayerDead.Invoke(playerDeadStruct);
    }

    void OnDead(PlayerDeadStruct pds)
    {
        Destroy(this);
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(.25f);
        isInvincible = false;
    }
}
