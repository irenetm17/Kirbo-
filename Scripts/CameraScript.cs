using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Kirbo;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Kirbo.transform.position.x;
        position.y = Kirbo.transform.position.y;
        if (Kirbo.transform.position.x > maxX) { position.x = maxX; }
        if (Kirbo.transform.position.y > maxY) { position.y = maxY; }
        if (Kirbo.transform.position.x < minX) { position.x = minX; }
        if (Kirbo.transform.position.y < minY) { position.y = minY; }
        transform.position = position;

    }
}
