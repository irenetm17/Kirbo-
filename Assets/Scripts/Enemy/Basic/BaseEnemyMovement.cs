using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Windows;

public class BaseEnemyMovement : MonoBehaviour
{
    // PARAMETERS
    public bool targeted = false;
    public float enemySpeed = 2.0f;
    public bool goingToEnd = false;
    public bool attacking = false;

    // COMPONENTS
    private GameObject _attackPlayerArea;
    public GameObject _startPath;
    public GameObject _endPath;
    
    private void Awake()
    {
        // INITIALIZE COMPONENTS
        _attackPlayerArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (targeted)
        {
            chase();
        }
        else
        {
            patrol();
        }
    }

    private void patrol()
    {
        _attackPlayerArea.SetActive(false);

        Transform pathTarget = goingToEnd ? _endPath.transform : _startPath.transform;
        transform.position = Vector3.MoveTowards(transform.position, pathTarget.position, enemySpeed * Time.deltaTime);
    }

    private void chase()
    {
        _attackPlayerArea.SetActive(true);

        Transform player = GameObject.FindWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        flipArea(player);

    }

    private void flipArea(Transform player)
    {
        Vector3 scale = _attackPlayerArea.transform.localScale;

        // IF MOVING LEFT
        if (transform.position.x  > player.position.x)
        {
            scale.x = -1.0f;

            Debug.Log("Flipped left");
        }
        else
        {
            scale.x = 1.0f;

            Debug.Log("Flipped right");
        }

        _attackPlayerArea.transform.localScale = scale;
    }
}
