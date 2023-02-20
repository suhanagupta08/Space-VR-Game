using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ButtonPress : MonoBehaviour
{
    private bool isPressed=false;

    public float buttonDepth = 0.1f;
    public float pressDuration = 0.5f;

    private Vector3 initialPosition;
    private float pressStartTime;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            isPressed = true;
            pressStartTime = Time.time;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isPressed && Time.time - pressStartTime < pressDuration)
        {
            transform.position = initialPosition - new Vector3(0, buttonDepth, 0);
            print("button pressed");
        }

        else
        {
            transform.position = initialPosition;
            isPressed = false;
        }
    }
    // void OnTriggerEnter(Collider other)
    // {
    //     print("in collision");
    //     if(!isPressed && other.gameObject.CompareTag("player"))
    //     {
    //         isPressed=true;
    //         print("button pressed");
    //         transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
    //     }
    // }


}
