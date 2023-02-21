using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ClimbWall : MonoBehaviour
{
    // Set the SteamVR input actions
    public SteamVR_Action_Boolean grabAction;

    // Set the hand objects
    public GameObject leftHand;
    public GameObject rightHand;

    // Set the maximum distance for grabbing objects
    public float maxGrabDistance = 2f;

    // Set the layer mask for detecting grabbable objects
    public LayerMask grabbableMask;

    // Store the currently grabbed object
    private GameObject grabbedObject;

    // Store the distance to the currently grabbed object
    private float grabbedDistance;

    // Store the Rigidbody component of the currently grabbed object
    private Rigidbody grabbedRigidbody;

    void Update()
    {
        // Check if the player is grabbing with either hand
        if (grabAction.GetStateDown(SteamVR_Input_Sources.LeftHand) || grabAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            // Raycast from the hand position to find a grabbable object
            Ray ray = new Ray();
            if (grabAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                ray.origin = leftHand.transform.position;
            }
            else if (grabAction.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                ray.origin = rightHand.transform.position;
            }
            ray.direction = ray.origin - transform.position;

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, maxGrabDistance, grabbableMask))
            {
                // Store the grabbed object and its distance
                grabbedObject = hitInfo.collider.gameObject;
                grabbedDistance = hitInfo.distance;

                // Store the Rigidbody component of the grabbed object
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            }
        }

        // Check if the player is currently grabbing an object
        if (grabbedObject != null)
        {
            // Move the grabbed object to the hand position
            Vector3 handPosition = Vector3.zero;
            if (grabAction.GetState(SteamVR_Input_Sources.LeftHand))
            {
                handPosition = leftHand.transform.position;
            }
            else if (grabAction.GetState(SteamVR_Input_Sources.RightHand))
            {
                handPosition = rightHand.transform.position;
            }
            grabbedObject.transform.position = handPosition + (transform.position - handPosition).normalized * grabbedDistance;

            // Apply a force to the grabbed object in the direction of the hand movement
            Vector3 handVelocity = Vector3.zero;
            if (grabAction.GetLastState(SteamVR_Input_Sources.LeftHand))
            {
                handVelocity = (leftHand.transform.position - leftHand.transform.position);
            }
            else if (grabAction.GetLastState(SteamVR_Input_Sources.RightHand))
            {
                handVelocity = (rightHand.transform.position - rightHand.transform.position);
            }
            grabbedRigidbody.AddForce(handVelocity * grabbedRigidbody.mass, ForceMode.Impulse);
        }

        // Check if the player is releasing an object
        if (grabAction.GetStateUp(SteamVR_Input_Sources.LeftHand) || grabAction.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            // Reset the grabbed object and its components
            grabbedObject = null;
            grabbedDistance = 0f;
            grabbedRigidbody = null;
        }
    }
}
