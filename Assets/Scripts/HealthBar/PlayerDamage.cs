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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(1);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            healKirbo(1);

        }
    }
        void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth); 
    }

    void healKirbo(int heal)
    {
        currentHealth += heal;
        healthBar.setHealth(currentHealth);
    }
}
