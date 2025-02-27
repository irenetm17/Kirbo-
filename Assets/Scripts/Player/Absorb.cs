using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    // PARAMETERS
    public bool absorbing = false;

    // COMPONENTS
    private SpriteRenderer _spriteRenderer;
    private GameObject absorbArea;
    private GameObject dissapearArea;

    void Awake()
    {
        // INITIALIZE COMPONENTS
        _spriteRenderer = GetComponent<SpriteRenderer>();
        absorbArea = transform.GetChild(0).gameObject;
        dissapearArea = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        // ABSORB WHEN PRESSING SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            absorbing = true;

            // PAINT THE SPRITE RED IF ABSORBING
            _spriteRenderer.color = Color.red;

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
    }
}
