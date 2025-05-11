using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    public GameObject respawn;
    

    [SerializeField] private AudioClip screamSound;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.playSoundClip(screamSound, transform, 0.5f);

            PlayerDamage damageScript = player.GetComponent<PlayerDamage>();
            if (damageScript != null)
            {
                damageScript.takeDamage(1);
            }
            player.transform.position = respawn.transform.position;


        }
    }
}
