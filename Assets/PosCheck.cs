using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheck : MonoBehaviour
{
    
    GameObject lever1;
    GameObject lever2;
    GameObject lever3;
    HingeJoint hinge1;
    HingeJoint hinge2;
    HingeJoint hinge3;
    public float threshold1=44.5f;
    public float threshold2=-44.5f;
    public float threshold3=44.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        lever1=GameObject.Find("Lever_1");
        lever2=GameObject.Find("Lever_2");
        lever3=GameObject.Find("Lever_3");
        hinge1= lever1.GetComponent<HingeJoint>();
        hinge2= lever2.GetComponent<HingeJoint>();
        hinge3= lever3.GetComponent<HingeJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Hinge1");
        print(hinge1.angle);
        print("Hinge2");
        print(hinge2.angle);
        print("Hinge3");
        print(hinge3.angle);
        if(hinge1.angle>=threshold1 ){
            print(" lever1 cleared");
        }

        if(hinge2.angle<=threshold2 ){
            print(" lever2 cleared");
        }

        if(hinge3.angle>=threshold3 ){
            print(" lever3 cleared");
        }

        if(hinge1.angle>=threshold1 && hinge2.angle<=threshold2 && hinge3.angle>=threshold3){
           //add scene change
            print(" obstacle cleared");
            // SceneManager.LoadScene("Shooting Game");
        }
    }
}
