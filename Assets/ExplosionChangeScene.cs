using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionChangeScene : MonoBehaviour
{
    public Transform playerTransform;
    public float detectionRadius = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
            print("reached door");
           // doorAnimation.Play("Base Layer.glass_door_open",0,-1);
            SceneManager.LoadScene("ClimbScene");
        }
    }
}
