// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Climber : MonoBehaviour
// {
//     public float gravity = 45.0f;
//     public float sensitivity = 45.0f;
//     public CHand currentHand = null;
//     private CharacterController controller =null;
// private void Awake()
// {
//     controller = GetComponent<CharacterController>();
// }
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         CalculateMovement();
//     }
//     private void CalculateMovement()
//     {
//         Vector3 movement = Vector3.zero;
//         if(currentHand)
//         {
//             movement += currentHand.Delta * sensitivity;
            
//         }
//         if(movement==Vector3.zero)
//         {
//             movement.y -= gravity*Time.deltaTime;
//         }
//         controller.Move(movement*Time.deltaTime);
            
//     }

//     public void SetHand(CHand hand)
//     {
//         if(currentHand)
//         {
//             currentHand.ReleasePoint();
//         }
//         currentHand=hand;
//     }
//     public void Clearhand()
//     {
//         currentHand = null;
//     }
// }
