using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int health=1;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                Hit(); 
            }
        }
    }

    private void Hit()
    {

    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
