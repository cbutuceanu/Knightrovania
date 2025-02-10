using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;

<<<<<<< Updated upstream
    private void Start()
    {
        currentHealth = maxHealth;
        
=======
    public int currentLives;
    public int maxLives;
    private PlayerMovement _playerMovement;
    
    

    private void Start()
    {
        currentHealth = maxHealth;
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
>>>>>>> Stashed changes
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp((currentHealth - damage), 0, maxHealth);

        if (currentHealth <= 0)
        {
            GameManager.instance.OnDeath();
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            _playerMovement.hitDuration = 2;
            // knock the player backwards

        }
       
    }
    
    
    
    
}
