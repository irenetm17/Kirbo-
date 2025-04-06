using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Respawn checkpoint;

    private void Awake()
    {
        checkpoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpoint.respawn = this.gameObject;
        }
    }
}
