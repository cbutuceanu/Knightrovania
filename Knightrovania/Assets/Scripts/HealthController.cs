using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;

    public int currentLives;
    public int maxLives;

    

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp((currentHealth - damage), 0, maxHealth);

        if (currentHealth == 0)
        {
           GameManager.instance.OnDeath();
            
        }
    }
    
    
    
    
}
