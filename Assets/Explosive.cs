using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Explosive : MonoBehaviour
{
    // [SerializeField] private GameObject obstacleExplosion;

    public float delay = 3f;
    public float radius = 5f;
    public float force = 5f;

    public GameObject explosionEffect;
    // public GameObject obstacle;
    // public ParticleSystem part;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start(){
        countdown = delay;
        // part = obstacle.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update(){
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded){
            Explode();
            hasExploded = true;
        }
    }

    void Explode(){
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders){
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && nearbyObject.gameObject.CompareTag("Obstacle")){
                rb.AddExplosionForce(force, transform.position, radius);

                Instantiate(explosionEffect, rb.transform.position, rb.transform.rotation);
                // part.Play();
                // Destroy(nearbyObject.gameObject, part.main.duration);
                Destroy(nearbyObject.gameObject);
            }
        }

        Destroy(gameObject);
    }
}
