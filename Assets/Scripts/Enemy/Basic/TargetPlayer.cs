using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Transform parentObject = transform.parent.parent;
            GameObject enemy = parentObject.GetChild(0).gameObject;

            BaseEnemyMovement enemyMovementScript = enemy.GetComponent<BaseEnemyMovement>();
            enemyMovementScript.targeted = !enemyMovementScript.targeted;
        }
    }
}
