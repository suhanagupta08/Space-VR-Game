using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Climbing : MonoBehaviour
{
    public Transform climbingTarget;
    public SteamVR_Action_Boolean input;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            climbingTarget = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            climbingTarget = null;
        }
    }

    void Update()
    {
        if (climbingTarget != null)
        {
            if(input.GetStateDown(SteamVR_Input_Sources.Any))
            {
                Vector3 climbVector = new Vector3(0, climbingTarget.position.y, 0);

                // Apply climbing to player
                transform.position += climbVector * Time.deltaTime;
            }
            
        }
    }
}

