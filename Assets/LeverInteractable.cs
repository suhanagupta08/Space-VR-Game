using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class LeverInteractable : MonoBehaviour
{
    public Transform leverPivot; // the pivot point of the lever
    public float minAngle = -45f; // the minimum angle the lever can rotate
    public float maxAngle = 45f; // the maximum angle the lever can rotate
    public UnityEvent onLeverPulled; // event to be triggered when the lever is pulled

    private Hand leverHand; // the hand that is currently holding the lever
    private float previousHandAngle; // the angle of the lever relative to the hand in the previous frame

    private Interactable interactable; // the interactable component attached to this object

    private void Start()
    {
        interactable = GetComponent<Interactable>();

        // set up the interaction events
        interactable.onAttachedToHand+=OnGrab;
        interactable.onDetachedFromHand+=OnRelease;
    }

    private void Update()
    {
        if (leverHand != null)
        {
            // calculate the current angle of the lever relative to the hand
            Vector3 handDirection = leverHand.transform.position - leverPivot.position;
            float handAngle = Vector3.SignedAngle(handDirection, Vector3.up, Vector3.forward);

            // calculate the delta angle from the previous frame
            float angleDelta = handAngle - previousHandAngle;

            // rotate the lever by the delta angle
            Vector3 euler = leverPivot.localEulerAngles;
            euler.z = Mathf.Clamp(euler.z + angleDelta, minAngle, maxAngle);
            leverPivot.localEulerAngles = euler;
            print(euler.z);

            // trigger the event if the lever has been pulled past a threshold angle
            if (euler.z >= maxAngle)
            {
                onLeverPulled.Invoke();
            }

            // store the current hand angle for the next frame
            previousHandAngle = handAngle;
        }
    }

    private void OnGrab(Hand hand)
    {
        leverHand = hand;

        // store the initial hand angle
        Vector3 handDirection = leverHand.transform.position - leverPivot.position;
        previousHandAngle = Vector3.SignedAngle(handDirection, Vector3.up, Vector3.forward);
    }

    private void OnRelease(Hand hand)
    {
        leverHand = null;
    }
}
