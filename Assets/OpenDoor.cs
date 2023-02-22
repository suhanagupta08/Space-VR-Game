using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class OpenDoor : MonoBehaviour
{
    public float detectionRadius = 1.00f;
    public Transform playerTransform;
    public Animator doorAnimation;

    public void OnPress(Hand hand)
    {
        Debug.Log("Button pressed");
        doorAnimation.Play("Base Layer.door_1_open", 0, -1);

    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
