using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
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
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            isMoving = true;
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            isMoving = false;
            other.transform.parent = null;
        }
    }
    
}
