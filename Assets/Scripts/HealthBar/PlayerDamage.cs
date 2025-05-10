using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;


     void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            
            healKirbo(1);    
            collision.gameObject.SetActive(false);  
        }else if (collision.CompareTag("Damage"))
        {
            takeDamage(1);
            collision.gameObject.SetActive(false) ;
        }
    }
    public void takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
    }

    void healKirbo(int heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += heal;
            healthBar.setHealth(currentHealth);
        }
    }
}