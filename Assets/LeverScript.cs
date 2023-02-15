using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LeverScript : MonoBehaviour
{
    public float rotationAngle = 45f; // The amount of rotation in degrees
    public Transform leverPivot; // The pivot point of the lever
    private float startAngle; // The starting angle of the lever

    private void Start()
    {
        startAngle = leverPivot.localRotation.eulerAngles.z;
    }

    private void HandAttachedUpdate(Hand hand)
    {
        float leverAngle = Mathf.Clamp(hand.GetTrackedObjectAngularVelocity().x, -1f, 1f) * rotationAngle;
        leverPivot.localRotation = Quaternion.Euler(0f, 0f, startAngle + leverAngle);
    }
}
