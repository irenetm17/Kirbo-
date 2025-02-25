using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AbsorbArea : MonoBehaviour
{
    public float absorbEnemySpeed = 5.0f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.transform.position = Vector3.MoveTowards(collider.transform.position, transform.parent.position, absorbEnemySpeed * Time.deltaTime);
        }
    }
}
