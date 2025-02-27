using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbDissapearArea : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.gameObject.SetActive(false);
        }
    }
}
