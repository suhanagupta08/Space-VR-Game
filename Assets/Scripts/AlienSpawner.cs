using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [Header("Size of the spawner area")]
    public Vector3 spawnerSize;

    [Header("Rate of spawn")]
    public float spawnRate = 1f;

    [Header("Model to spawn")]
    [SerializeField] private GameObject AlienModel;

    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);    
    }

    int count = 0;

    private void Update() 
    {
        spawnTimer += Time.deltaTime;    

        if(spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            SpawnAliens();
            count += 1;
            Debug.Log(count);
        }

        if(count >= 5)
        {
            enabled = false;
            return;
        }
    }

    private void SpawnAliens()
    {
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x/2, spawnerSize.x/2),
                                                                UnityEngine.Random.Range(-spawnerSize.y/2, spawnerSize.y/2),
                                                                UnityEngine.Random.Range(-spawnerSize.z/2, spawnerSize.z/2));
                                                                
        GameObject alien = Instantiate(AlienModel, spawnPoint, transform.rotation);     

        alien.transform.SetParent(this.transform);                                                  
    }
}
