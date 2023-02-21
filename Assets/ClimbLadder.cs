using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ClimbLadder : MonoBehaviour
{
    public Transform handAnchor; // the hand anchor for the player's controller
    public Transform ladderTop; // the top of the ladder
    public Transform ladderBottom; // the bottom of the ladder
    public float climbSpeed = 2f; // the speed at which the player climbs
    public float climbThreshold = 0.1f; // the distance at which the player can climb the ladder

    private bool isClimbing = false; // whether the player is currently climbing the ladder
    private Rigidbody playerRb; // the player's rigidbody component

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // check if the player is close enough to the ladder to climb it
        if (!isClimbing && handAnchor != null && Vector3.Distance(handAnchor.position, ladderTop.position) < climbThreshold)
        {
            StartClimbing();
        }
        // check if the player has reached the top of the ladder
        if (isClimbing && transform.position.y > ladderTop.position.y)
        {
            StopClimbing();
        }
    }

    void FixedUpdate()
    {
        // move the player up the ladder
        if (isClimbing)
        {
            playerRb.MovePosition(transform.position + Vector3.up * climbSpeed * Time.fixedDeltaTime);
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        playerRb.useGravity = false;
        playerRb.isKinematic = true;
    }

    void StopClimbing()
    {
        isClimbing = false;
        playerRb.useGravity = true;
        playerRb.isKinematic = false;
    }
}
