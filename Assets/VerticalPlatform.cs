using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float detectionRadius = 1.5f;
    public GameObject other;
    public Transform playerTransform;
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    private Vector3 currentTarget;
    private bool isMoving = false;

    void Start()
    {
        currentTarget = pointB.position;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                currentTarget = pointB.position;
            }
            else if (transform.position == pointB.position)
            {
                currentTarget = pointA.position;
                isMoving = false;
            other.transform.parent = null;
            }
        }
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
             isMoving = true;
            other.transform.parent = transform;
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("player"))
    //     {
    //         isMoving = true;
    //         other.transform.parent = transform;
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("player"))
    //     {
    //         isMoving = false;
    //         other.transform.parent = null;
    //     }
    // }
    
}
