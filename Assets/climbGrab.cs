using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class climbGrab : MonoBehaviour
{
    private Interactable interactable; 



    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();   
    }

    void HandHoverUpdate(Hand hand)
{
    GrabTypes grabType = hand.GetGrabStarting();
    bool isGrabEnding = hand.IsGrabEnding(gameObject);

    if(interactable.attachedToHand == null && grabType != GrabTypes.None){
        // Create a new fixed joint and connect it to the hand
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = hand.gameObject.GetComponent<Rigidbody>();

        // Set the joint to break force to infinity, so it won't break unless the object is intentionally released
        joint.breakForce = Mathf.Infinity;

        // Disable the interactable component, so the object won't be dropped when releasing the grab button
        interactable.enabled = false;

        // Hide the grab hint and lock the hand in place
        hand.HideGrabHint();
        hand.HoverLock(interactable);
    } else if(isGrabEnding){
        // Remove the fixed joint and re-enable the interactable component
        FixedJoint joint = gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
        interactable.enabled = true;

        // Unlock the hand and show the grab hint again
        hand.HoverUnlock(interactable);
        hand.ShowGrabHint();
    }
}

}
