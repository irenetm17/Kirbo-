using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject niña;
    public float paralaxFactor = 0.5f;
    Camera camera1;
    Vector3 initialCameraPosition;
    Vector3 initialPosition;
    public bool reset = false;
    void Start()
    {
        camera1 = Camera.main;
        initialCameraPosition = camera1.transform.position;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            Vector3 cameraOffset = camera1.transform.position - initialCameraPosition;
            transform.position = transform.position + cameraOffset * paralaxFactor;
            initialCameraPosition = camera1.transform.position;
        };
        if ((niña.transform.position.y <= -800.0f) && (reset == false))
        {
            initialCameraPosition = camera1.transform.position;
            transform.position = initialPosition;
            reset = true;
        };
    }
}
