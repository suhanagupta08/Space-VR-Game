using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ClimbingWall : MonoBehaviour
{
    // Set the SteamVR input actions
    public SteamVR_Action_Boolean grabAction;

    // Set the hand objects
    public GameObject leftHand;
    public GameObject rightHand;

    // Set the climbing speed and gravity
    public float climbingSpeed = 5f;
    public float gravity = 9.81f;

    // Store the current climbing direction
    private Vector3 climbingDirection;

    // Store the player's current hand positions
    private Vector3 leftHandPosition;
    private Vector3 rightHandPosition;

    // Store the climbing object's original position and rotation
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Store the Rigidbody component
    private Rigidbody rb;

    // Store the climbing state
    private bool isClimbing = false;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Store the original position and rotation of the climbing object
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Check if the player is grabbing with either hand
        if (grabAction.GetStateDown(SteamVR_Input_Sources.LeftHand) || grabAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            // Store the current hand positions
            leftHandPosition = leftHand.transform.position;
            rightHandPosition = rightHand.transform.position;

            // Calculate the initial climbing direction
            climbingDirection = (leftHandPosition - rightHandPosition).normalized;

            // Set the climbing state to true
            isClimbing = true;
        }

        // Check if the player is releasing with either hand
        if (grabAction.GetStateUp(SteamVR_Input_Sources.LeftHand) || grabAction.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            // Reset the climbing state
            isClimbing = false;

            // Reset the climbing object's position and rotation
            transform.position = originalPosition;
            transform.rotation = originalRotation;

            // Reset the Rigidbody component
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // If the player is climbing
        if (isClimbing)
        {
            // Calculate the current hand positions
            leftHandPosition = leftHand.transform.position;
            rightHandPosition = rightHand.transform.position;

            // Calculate the current climbing direction
            climbingDirection = (leftHandPosition - rightHandPosition).normalized;

            // Apply a force in the climbing direction
            rb.AddForce(climbingDirection * climbingSpeed, ForceMode.Acceleration);

            // Apply gravity to the climbing object
            rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }
}