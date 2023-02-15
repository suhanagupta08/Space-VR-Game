using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public Transform playerTransform;

    [Header("MinSpeed")]
    public float minSpeed = 5f;
    [Header("MaxSpeed")]
    public float maxSpeed = 10f;
    private float speed;
    private float timer;

    [Header("rotationSpeed")]
    public float rotationSpeed = 2f;

    private Rigidbody obstacleRigidbody;
    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        // Debug.Log(direction);
        speed = Random.Range(minSpeed,maxSpeed);
        obstacleRigidbody.velocity = direction * Time.deltaTime * speed;
        // Debug.Log(speed);
        timer += Time.deltaTime;

        if (timer >= rotationSpeed)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            timer = 0.0f;
        }       

    }
}
