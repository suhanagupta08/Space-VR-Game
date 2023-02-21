using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandAttachment : MonoBehaviour
{
    public bool isAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Hand hand = other.GetComponent<Hand>();
            if (hand != null)
            {
                GrabTypes grabType = hand.GetGrabStarting();
                hand.AttachObject(gameObject, grabType);
                isAttached = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isAttached)
        {
            Hand hand = other.GetComponent<Hand>();
            if (hand != null)
            {
                hand.DetachObject(gameObject);
                isAttached = false;
            }
        }
    }
}
