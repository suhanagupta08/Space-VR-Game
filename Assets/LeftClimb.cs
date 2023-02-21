using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using UnityEngine;
using Valve.VR;

public class LeftClimb : MonoBehaviour
{
    public bool climbing = false;
    public GameObject climbingWall;
    public GameObject climbingHand;
    public Vector3 handClimbingOffset = new Vector3(0, -0.2f, 0);
    public float climbSpeed = 1.5f;
    public SteamVR_Action_Boolean grip;
    // public string gripButtonName = "GrabGrip";
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.LeftHand;

    private void OnCollisionEnter(Collision collision)
    {
        print("collding");
        if (collision.gameObject.tag == "Climbable")
        {
            print("collding cliumbable");
            if (grip.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                print("Collision Detected");
                climbing = true;
                climbingWall = collision.gameObject;
                climbingHand = gameObject;
                climbingHand.transform.position = collision.contacts[0].point;
                print(collision.contacts[0].point);

                climbingHand.transform.rotation = Quaternion.LookRotation(-collision.contacts[0].normal, transform.up);
            }
        }
    }

    private void Update()
    {
        if (climbing)
        {
            climbingHand.transform.position = climbingWall.transform.TransformPoint(handClimbingOffset);
            transform.position += climbingWall.transform.up * climbSpeed * Time.deltaTime;
            if (grip.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                climbing = false;
                climbingWall = null;
                climbingHand = null;
            }
        }
    }
}
