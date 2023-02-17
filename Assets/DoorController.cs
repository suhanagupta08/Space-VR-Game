using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectionRadius = 2.5f;
    public Transform playerTransform;
    private Animator doorAnimation;
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
            print("reached door");
            doorAnimation.Play("Base Layer.glass_door_open",0,-1);
        }
    }
}
