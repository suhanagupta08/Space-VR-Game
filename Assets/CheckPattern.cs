using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPattern : MonoBehaviour
{
    public Transform lever1Pivot;
    public Transform lever2Pivot;
    public Transform lever3Pivot;
    public float reqAngle1 = -45f;
    public float reqAngle2 = 45f;
    public float reqAngle3 = -45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 euler1 = lever1Pivot.localEulerAngles;
         Vector3 euler2 = lever2Pivot.localEulerAngles;
         Vector3 euler3 = lever3Pivot.localEulerAngles;

         print(euler1.z);

         if(reqAngle1==euler1.z && reqAngle2==euler2.z && reqAngle3==euler3.z){
            // print("lever obstacle cleared");
         }
        
    }
}
