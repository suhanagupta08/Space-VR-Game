using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMovement : MonoBehaviour
{
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Vector2 touchpadAction;
    public float moveSpeed = 2.0f;

    void Update()
    {
        // Get input from touchpad
        Vector2 touchpadValue = touchpadAction.GetAxis(inputSource);

        // Calculate movement vector
        Vector3 moveVector = new Vector3(touchpadValue.x, 0, touchpadValue.y);

        // Apply movement to camera rig
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
