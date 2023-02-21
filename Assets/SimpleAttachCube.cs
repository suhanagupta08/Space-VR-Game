using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttachCube : MonoBehaviour
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
        Debug.Log("In hand hover update");

        if(interactable.attachedToHand == null && grabType != GrabTypes.None){
            Debug.Log("Attached");
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }else if(isGrabEnding){
            Debug.Log("Detached");
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
