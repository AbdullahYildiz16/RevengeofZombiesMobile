using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItem : MonoBehaviour
{
    PlayerHealth playerHealth;
    

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem"))
        {
            playerHealth.AddHealth(10);
            other.gameObject.SetActive(false);
            
        }
        
    }
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        
    }



}
