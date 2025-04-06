using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAttack : MonoBehaviour
{
    public float attackSpeed = 2.0f;
    private float timer = 0f;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            attack();
        }
    }

    private void attack()
    {
        Transform enemy = transform.parent;

        BaseEnemyMovement enemyMovementScript = enemy.GetComponent<BaseEnemyMovement>();
        enemyMovementScript.attacking = true;

        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            Debug.Log("Player attacked");

            timer = 0f;
            enemyMovementScript.attacking = false;
        }   
    }
}
