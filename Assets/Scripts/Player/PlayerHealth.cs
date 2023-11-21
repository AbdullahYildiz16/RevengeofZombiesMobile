using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public Text Died;

    AudioSource audio;
    public AudioClip hit;
    public AudioClip deadPlayer;
    

    public Text Health;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        Health.text = "= " + currentHealth;
    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        audio.clip = hit;
        audio.Play();
        
        

        if (currentHealth <= 0)
        {
            
            StartCoroutine(KillPlayer());
        }
    }

    IEnumerator KillPlayer()
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        audio.clip = deadPlayer;
        audio.Play();
        Died.text = "You Died!";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }

    public void AddHealth(int value)
    {
        currentHealth = currentHealth + value;
        
        if (currentHealth > 100)
        {
            currentHealth = maxHealth;
            
        }
    }
    
    
    void Update()
    {
        Health.text = "= " + currentHealth;
    }
}
