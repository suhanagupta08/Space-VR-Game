using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private bool isPressed=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        print("in collision");
        if(!isPressed && other.gameObject.CompareTag("player"))
        {
            isPressed=true;
            print("button pressed");
            transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
        }
    }
}
