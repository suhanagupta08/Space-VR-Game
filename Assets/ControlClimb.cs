using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControlClimb : MonoBehaviour
{
    public SteamVR_Action_Boolean climbAction;
    public float climbSpeed = 1.0f;
    private bool isClimbing = false;
    private Transform climbTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        climbAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "Climb");
    }



    private void StartClimbing() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f)) {
            if (hit.transform.CompareTag("Climbable")) {
                isClimbing = true;
                climbTarget = hit.transform;
            }
        }
    }

    private void StopClimbing() {
        isClimbing = false;
        climbTarget = null;
    }



    // Update is called once per frame
    void Update()
    {
        if (climbAction.GetStateDown(SteamVR_Input_Sources.LeftHand) || climbAction.GetStateDown(SteamVR_Input_Sources.RightHand)) {
            StartClimbing();
        } else if (climbAction.GetStateUp(SteamVR_Input_Sources.LeftHand) || climbAction.GetStateUp(SteamVR_Input_Sources.RightHand)) {
            StopClimbing();
        }

        if (isClimbing) {
            Vector3 climbDirection = climbTarget.position - transform.position;
            climbDirection.y = 0;
            climbDirection.Normalize();
            transform.position += climbDirection * climbSpeed * Time.deltaTime;
        }

    }

    
}
