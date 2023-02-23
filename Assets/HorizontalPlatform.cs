using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float detectionRadius = 2.0f;
    public GameObject other;
    public Transform playerTransform;
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    private Vector3 currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            other.transform.parent = null;
        }
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
            other.transform.parent = transform;
        }

    }
}
