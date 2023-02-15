using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    
    public LineRenderer lineRenderer;
    private AudioSource laserAudioSource;
    private RaycastHit hit;
    
    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        //animate the gun 
        laserAnimator.SetTrigger("Fire");

        //play laser gun SFX
        laserAudioSource.PlayOneShot(laserSFX);
        
        //RayCast
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 1000f))
        {
            
            // lineRenderer.SetPosition(0,);
            // lineRenderer.SetPosition(1, hit.point);
            
            if(hit.transform.GetComponent<AlienHit>() != null)
            {
                hit.transform.GetComponent<AlienHit>().alienDestroyed();
            }
        }
    }
}