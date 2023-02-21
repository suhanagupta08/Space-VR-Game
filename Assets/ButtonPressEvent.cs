using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonPressEvent : MonoBehaviour
{
    public Light light;
    public void OnPress(Hand hand)
    {
        Debug.Log("Button pressed");
        light.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
