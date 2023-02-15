using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;
    private Vector3 currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget,speed*Time.deltaTime);
        if(transform.position == endPoint.position)
        {currentTarget = startPoint.position;}
        else if(transform.position == startPoint.position)
        {
            currentTarget=endPoint.position;
        }
    }
}
