using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectionRadius = 2.0f;
    public Transform playerTransform;
    private Animation doorAnimation;
    void Start()
    {
        doorAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
            doorAnimation.Play("glass_door_open ");
        }
    }
}
