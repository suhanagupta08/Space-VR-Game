using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeExplosion : MonoBehaviour
{
    /*new code*/
    [SerializeField] private GameObject obstacleExplosion;
    /*end new code*/

    public float explosionForce = 3f;
    public float explosionRadius = 10f;
    public float fadeOutTime = 2f;

    private Rigidbody rb;
    private Renderer rend;
    private float startTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            // Add an explosion force to the cube
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody hitRb = hit.GetComponent<Rigidbody>();
                if (hitRb != null && hit.gameObject.CompareTag("Obstacle"))
                {
                    hitRb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 10f, ForceMode.Impulse);

                    /*new code*/
                    Instantiate(obstacleExplosion, transform.position, transform.rotation);
                    Destroy(hit.gameObject);
                    /*end new code*/
                    
                    // hit.gameObject.GetComponent<Renderer>().enabled = false;
                    // hit.gameObject.GetComponent<Collider>().enabled = false;
                    // Destroy(hit.gameObject, 5f);
                }
            }

            // Start fading out the cube
            startTime = Time.time;
        }
    }

    private void Update()
    {
        if (startTime > 0)
        {
            float elapsedTime = Time.time - startTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeOutTime);
            Color color = rend.material.color;
            color.a = alpha;
            rend.material.color = color;

            if (elapsedTime >= fadeOutTime)
            {
                Destroy(gameObject);
            }
        }
    }
}