// using UnityEngine;
// using Valve.VR;
// using System.Collections;
// using System.Collections.Generic;

// public class LeverController : MonoBehaviour
// {
//     [SerializeField] private Transform leverArm; // Reference to the lever arm object
//     [SerializeField] private float leverSpeed = 1f; // Speed at which the lever arm moves
//     [SerializeField] private float maxRotationAngle = 45f; // Maximum rotation angle of the lever arm
//     [SerializeField] private SteamVR_Input_Sources handType; // The type of hand to track

//     private Vector3 handStartPosition; // The starting position of the hand in VR
//     private Vector3 handCurrentPosition; // The current position of the hand in VR
//     private Quaternion handStartRotation; // The starting rotation of the hand in VR
//     private Quaternion handCurrentRotation; // The current rotation of the hand in VR

//     private void Start()
//     {
//         handStartPosition = SteamVR_Input.GetLocalPosition(handType);
//         handStartRotation = SteamVR_Input.GetLocalRotation(handType);
//     }

//     private void Update()
//     {
//         handCurrentPosition = SteamVR_Input.GetLocalPosition(handType);
//         handCurrentRotation = SteamVR_Input.GetLocalRotation(handType);

//         Vector3 handPositionDelta = handCurrentPosition - handStartPosition; // Calculate the change in position of the hand
//         Quaternion handRotationDelta = handCurrentRotation * Quaternion.Inverse(handStartRotation); // Calculate the change in rotation of the hand

//         float handRotationAngle = Mathf.Clamp(handRotationDelta.eulerAngles.z, -maxRotationAngle, maxRotationAngle); // Convert the rotation change to an angle within the maximum range
//         leverArm.localRotation = Quaternion.Euler(handRotationAngle, 0f, 0f); // Apply the rotation to the lever arm

//         float leverAngle = leverArm.localRotation.eulerAngles.x; // Get the current angle of the lever arm
//         float leverTorque = Mathf.Lerp(-1f, 1f, (leverAngle + maxRotationAngle) / (maxRotationAngle * 2f)); // Calculate the amount of torque to apply based on the lever angle
//         leverArm.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * leverTorque * leverSpeed); // Apply the torque to the lever arm
//     }
// }
