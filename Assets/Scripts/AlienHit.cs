using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHit : MonoBehaviour
{
    [SerializeField] private GameObject alienExplosion;

    public void alienDestroyed()
    {
        Instantiate(alienExplosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
