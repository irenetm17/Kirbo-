using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            BaseEnemyMovement enemyMovementScript = collider.GetComponent<BaseEnemyMovement>();
            enemyMovementScript.goingToEnd = !enemyMovementScript.goingToEnd;
        }
    }
}
