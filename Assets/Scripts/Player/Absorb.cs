using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    // PARAMETERS
    public bool absorbing = false;
    [SerializeField] private AudioClip absorbSound;

    // COMPONENTS
    private GameObject absorbArea;
    private GameObject dissapearArea;
    private Animator _animator;

    void Awake()
    {
        // INITIALIZE COMPONENTS
        absorbArea = transform.GetChild(0).gameObject;
        dissapearArea = transform.GetChild(1).gameObject;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ABSORB WHEN PRESSING SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("empiezaAbsorber");

            absorbing = true;

            SoundManager.instance.playSoundClip(absorbSound, transform, 1f);

            // ENABLE COLLIDERS
            absorbArea.SetActive(absorbing);
            dissapearArea.SetActive(absorbing);
        }

        // STOP ABSORBING WHEN SPACE IS RELEASED
        if (Input.GetKeyUp(KeyCode.Space))
        {
            absorbing = false;

            // DISABLE COLLIDERS
            absorbArea.SetActive(absorbing);
            dissapearArea.SetActive(absorbing);
        }

        _animator.SetBool("absorbing", absorbing);
    }
}
