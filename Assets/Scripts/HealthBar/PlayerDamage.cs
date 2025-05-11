using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;

    [SerializeField] private AudioClip bonusSound;
    [SerializeField] private AudioClip damageSound;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Health"))
        {
            healKirbo(1);    
            trigger.gameObject.SetActive(false);
        }
        else if (trigger.CompareTag("Damage"))
        {
            takeDamage(1);
            trigger.gameObject.SetActive(false) ;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(1);
        }
    }
    public void takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            SoundManager.instance.playSoundClip(damageSound, transform, 0.5f);

            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void healKirbo(int heal)
    {
        if (currentHealth < maxHealth)
        {
            SoundManager.instance.playSoundClip(bonusSound, transform, 0.3f);

            currentHealth += heal;
            healthBar.setHealth(currentHealth);
        }
    }
}