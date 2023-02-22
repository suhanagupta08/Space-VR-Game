using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door3Open : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectionRadius = 2.0f;
    public Transform playerTransform;
    private Animator doorAnimation;
    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
            print("reached door");
            doorAnimation.Play("Base Layer.door_3_open", 0, -1);
            SceneManager.LoadScene("EndScene");
        }
    }
}