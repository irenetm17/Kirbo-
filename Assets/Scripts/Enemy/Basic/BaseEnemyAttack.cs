using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyAttack : MonoBehaviour
{
    public float attackSpeed = 0.001f;
    private float timer = 0f;
    private int attackPower = 1;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerDamage scriptdamage = collider.gameObject.GetComponent<PlayerDamage>();
            attack(scriptdamage);
        }
    }

    private void attack(PlayerDamage script)
    {
        Transform enemy = transform.parent;

        BaseEnemyMovement enemyMovementScript = enemy.GetComponent<BaseEnemyMovement>();
        enemyMovementScript.attacking = true;

        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            script.takeDamage(attackPower);
            Debug.Log("Player attacked");

            timer = 0f;
            enemyMovementScript.attacking = false;
        }
    }
}
