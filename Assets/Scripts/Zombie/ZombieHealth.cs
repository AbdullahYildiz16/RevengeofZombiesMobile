using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int startHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void Hit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            // Zombie öldü!

        }

    }


}    
