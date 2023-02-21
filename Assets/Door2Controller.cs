using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectionRadius = 1.00f;
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
            doorAnimation.Play("Base Layer.door_2_open", 0, -1);
        }
    }
}
