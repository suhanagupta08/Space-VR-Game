using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheck : MonoBehaviour
{
    HingeJoint hinge;
    public float threshold=44.5f;
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        hinge= GetComponent<HingeJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print(hinge.angle);
        if(hinge.angle>=threshold){
            print("cleared");
        }
    }
}
