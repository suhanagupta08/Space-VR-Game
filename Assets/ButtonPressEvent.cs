using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonPressEvent : MonoBehaviour
{
    public void OnPress(Hand hand)
    {
        Debug.Log("Button pressed");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
