using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttach : MonoBehaviour
{
    private Interactable interactable;
    public CharacterController characterController;
    public Transform player;



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
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();

            MovePlayer();


        }else if(isGrabEnding){
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }

    public void MovePlayer(){
        characterController.Move(new Vector3(player.position.x, player.position.y + 10f, player.position.z));
    }
}
