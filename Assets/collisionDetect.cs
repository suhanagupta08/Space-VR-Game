using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
    public CharacterController characterController;

    private Vector3 playerVelocity;
    private float upVelocity = 0.8f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
         print("colliding ");
         playerVelocity.y = upVelocity;

        //  characterController.Move(playerVelocity * Time.deltaTime);
        player.position = player.position + new Vector3(0, 0.8f, 0);
        
    }
}
