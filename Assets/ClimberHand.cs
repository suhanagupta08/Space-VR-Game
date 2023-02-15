using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ClimberHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SteamVR_Input_Sources Hand;
    public int TouchedCount;
    public bool grabbing;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            TouchedCount--;
        }
    }
}
