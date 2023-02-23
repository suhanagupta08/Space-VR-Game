using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
//using Valve.VR.in

public class ClimbUp : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public SteamVR_Action_Boolean jumpInput;
    public SteamVR_Action_Boolean crouchInput;
    public float speed = 2.0f;
    public float jumpHeight = 1.0f;
    public float crouchHeight = 0.5f;
    public float gravityValue = -9.81f;
    private CharacterController characterController;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        
        if(groundedPlayer && playerVelocity.y<0)
        {
            playerVelocity.y=0f;
        }
        if(input.axis.magnitude >0.1f)
        {
            Vector3 direction = transform.right*input.axis.x+transform.up*input.axis.y;
            characterController.Move(speed * Time.deltaTime * direction);
    // characterController.Move(speed * Time.deltaTime * new Vector3(input.axis.x,0,input.axis.y) - new Vector3(0,9.81f,0*Time.deltaTime));
   
        }
        if(characterController.isGrounded && crouchInput.GetStateDown(SteamVR_Input_Sources.Any))
        {
characterController.height=crouchHeight;
        }
        if(crouchInput.GetStateUp(SteamVR_Input_Sources.Any))
        {
            characterController.height=2f;
        }
        if(characterController.isGrounded && jumpInput.GetStateDown(SteamVR_Input_Sources.Any))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight* -3.0f * gravityValue);
            
        }
//         else
//         {
// playerVelocity.y += gravityValue * Time.deltaTime;
//         }

        
        
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
